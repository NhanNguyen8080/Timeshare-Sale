using Azure;
using BackendTimeshareSale.Service.IServices;
using Elasticsearch.Net;
using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BackendTimeshareSale.Service.ServiceImp
{
    public class ElasticsearchService<T> : IElasticsearchService<T> where T : class
    {
        private readonly ElasticClient _elasticClient;

        public ElasticsearchService(ElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task<bool> CreateDocument(T entity)
        {
            var response = await _elasticClient.IndexDocumentAsync(entity);
            if (response.IsValid)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<T>> GetAllDocuments()
        {
            var response = await _elasticClient.SearchAsync<T>(_ => _.MatchAll().Size(10000));
            var result = response.Documents;
            return response.Documents;
        }

        public T GetDocument(int id)
        {
            var searchResponse = _elasticClient.Search<T>(s => s
            .Query(q => q
                .Term(t => t
                    .Field("propertyId")
                    .Value(id)
                )
            )
        );
            return searchResponse.Documents.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> GetDocuments(string keyword)
        {

            var searchResponse = await _elasticClient.SearchAsync<T>(s => s
                .Query(
                    q => q.QueryString(
                        qs => qs.Query('*'+keyword+'*')
                    )
                ).Size(10000)
            );

            if (searchResponse.IsValid)
            {
                var result = searchResponse.Documents.ToList();
                return result;
            }
            else
            {
                throw new Exception($"Search failed: {searchResponse.DebugInformation}");
            }
        }

        public async Task<bool> IndexData(IEnumerable<T> entities)
        {
            try
            {
                var indexResponse = await _elasticClient.IndexManyAsync(entities);

                if (!indexResponse.IsValid) 
                {
                    // Handle indexing failure
                    Console.WriteLine($"Bulk indexing failed: {indexResponse.DebugInformation}");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred while indexing data: {ex.Message}");
                return false;
            }
        }
    }
}
