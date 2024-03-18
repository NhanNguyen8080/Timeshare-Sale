using BackendshareSale.Repo.Interfaces;
using BackendshareSale.Repo.Models;
using BackendTimeshareSale.Service.IServices;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Nest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using BackendshareSale.Repo.ViewModel;
using AutoMapper;

namespace BackendTimeshareSale.Service.ServiceImp
{
    public class PropertyService : IPropertyService
    {
        private readonly IElasticsearchService<Property> _elasticsearchService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PropertyService(IElasticsearchService<Property> elasticsearchService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _elasticsearchService = elasticsearchService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        public async Task<PropertyVM> GetById(int id)
        {
            return _mapper.Map<PropertyVM>(_elasticsearchService.GetDocument(id));
        }

        public int GetAllOfProperties()
        {
            var result = _unitOfWork.PropertyRepo.GetAll().ToList().Count;
            return result;
        }

        public Task<bool> IndexData(IEnumerable<Property> entities)
        {
            return _elasticsearchService.IndexData(entities);
        }

        public int NumberOfPropertiesAreAvailable(int month)
        {
            var available = _unitOfWork.BookingDetailRepo.Get(_ => _.CheckInDate.Value.Month > month || _.CheckOutDate.Value.Month < month).ToList().Count;

            return available;
        }

        public int NumberOfPropertiesAreBooking(int month)
        {
            var booking = _unitOfWork.BookingDetailRepo.Get(_ => _.CheckInDate.Value.Month <= month && _.CheckOutDate.Value.Month >= month).ToList().Count;
            return booking;
        }

        public double PercentOfAvailableProperty(int month)
        {
            var total = _unitOfWork.PropertyRepo.GetAll().ToList().Count;
            var available = _unitOfWork.BookingDetailRepo.Get(_ => _.CheckInDate.Value.Month > month || _.CheckOutDate.Value.Month < month).ToList().Count;
            var percent = (double)available / total;

            return percent;
        }


        public void InsertDataToSQL()
        {
            var dataList = new List<Property>();
            // Create 10,000 Property objects and add them to the list
            //string imagePath = "D:\\StudyDocuments\\SWD392\\Group-Project\\Backend\\src\\BackendTimeshareSale\\BackendTimeshareSale\\images\\R.jpg"; // Replace "file.jpg" with the path to your image file
            //byte[] imageData = File.ReadAllBytes(imagePath);
            for (int i = 1; i <= 10000; i++)
            {
                Property property = new Property
                {
                    PropertyId = i,
                    PropertyName = $"Property {i}",
                    PropertyType = "Type",
                    Country = "Country",
                    Address = "Address",
                    Price = 100000,
                    IsAvailable = true,
                    Description = "Description",
                    Images = "https://th.bing.com/th/id/OIP.Go1_a1LzN1-l-lxSXDlPCgHaEK?w=284&h=180&c=7&r=0&o=5&cb=11&dpr=1.3&pid=1.7",
                    LastUpdate = DateTime.Now,
                    OwnerId = 1 // Change this according to your requirement
                };

                dataList.Add(property);

            }
            BulkInsertProperties(dataList);
        }

        private void BulkInsertProperties(List<Property> properties)
        {
            DataTable table = new DataTable();
            table.TableName = "[dbo].[Properties]";

            table.Columns.Add(nameof(Property.PropertyId), typeof(int));
            table.Columns.Add(nameof(Property.PropertyName), typeof(string));
            table.Columns.Add(nameof(Property.PropertyType), typeof(string));
            table.Columns.Add(nameof(Property.Country), typeof(string));
            table.Columns.Add(nameof(Property.Address), typeof(string));
            table.Columns.Add(nameof(Property.Price), typeof(decimal));
            table.Columns.Add(nameof(Property.IsAvailable), typeof(bool));
            table.Columns.Add(nameof(Property.Description), typeof(string));
            table.Columns.Add(nameof(Property.LastUpdate), typeof(DateTime));
            table.Columns.Add(nameof(Property.Images), typeof(string));
            table.Columns.Add(nameof(Property.OwnerId), typeof(int));
            foreach (var property in properties)
            {
                var row = table.NewRow();

                row[nameof(Property.PropertyId)] = property.PropertyId;
                row[nameof(Property.PropertyName)] = property.PropertyName;
                row[nameof(Property.PropertyType)] = property.PropertyType;
                row[nameof(Property.Country)] = property.Country;
                row[nameof(Property.Address)] = property.Address;
                row[nameof(Property.Price)] = property.Price;
                row[nameof(Property.IsAvailable)] = property.IsAvailable;
                row[nameof(Property.Description)] = property.Description;
                row[nameof(Property.LastUpdate)] = property.LastUpdate;
                row[nameof(Property.Images)] = property.Images;
                row[nameof(Property.OwnerId)] = property.OwnerId;

                table.Rows.Add(row);
            }
            using (var bulkInsert = new SqlBulkCopy(GetConnectionString()))
            {
                //bulkInsert.EnableStreaming = true;
                bulkInsert.DestinationTableName = table.TableName;
                bulkInsert.WriteToServer(table);
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var strConn = config["ConnectionStrings:Database"];
            return strConn;
        }

        public async Task<IEnumerable<PropertyVM>> GetAllProperties()
        {
            var query = await _elasticsearchService.GetAllDocuments();
            var result = _mapper.Map<IEnumerable<PropertyVM>>(query);
            return result;
        }

        public async Task<IEnumerable<PropertyVM>> SearchProperties(string keyword)
        {
            var query = await _elasticsearchService.GetDocuments(keyword);
            var result = _mapper.Map<IEnumerable<PropertyVM>>(query);
            return result;
        }

        public async Task<string> CreateDocument(Property entity)
        {
            var check = await _elasticsearchService.CreateDocument(entity);
            if (check)
            {
                return "Index data successfully!";
            }
            return "Index data failed!";
        }

        public double PercentOfBookingProperty(int month)
        {
            var total = _unitOfWork.PropertyRepo.GetAll().ToList().Count;
            var booking = _unitOfWork.BookingDetailRepo.Get(_ => _.CheckInDate.Value.Month <= month && _.CheckOutDate.Value.Month >= month).ToList().Count;
            double percent = (double)booking / total;

            return percent * 100;
        }
    }
}
