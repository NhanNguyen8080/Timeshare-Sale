import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { toast } from "react-toastify";
import { api } from "../../utils/api";
import Map from "../../Map/Map";

import { PuffLoader } from "react-spinners";
import { FaShower } from "react-icons/fa";
import { AiTwotoneCar } from "react-icons/ai";
import { MdLocationPin, MdMeetingRoom } from "react-icons/md";

const PropertyDetails = () => {
  const { id } = useParams();
  const [property, setProperty] = useState(null);

  useEffect(() => {
    const fetchPropertyDetails = async () => {
      try {
        const response = await api.get(`/properties/${id}`);
        setProperty(response.data);
      } catch (error) {
        toast.error("Failed to fetch property details");
      }
    };

    fetchPropertyDetails();
  }, [id]);

  if (!property) {
    return <div className="flexCenter paddings">
        Loading...
        <PuffLoader />
    </div>;
  }

  return (
    
     <div className="wrapper">
     <div className="flexColStart paddings innerWidth property-container">
       {/* like button */}
       {/* <div className="like">
         <Heart id={id}/>
       </div> */}

       {/* image */}
       <img src={property?.image} alt="home image" />

       <div className="flexCenter property-details">
         {/* left */}
         <div className="flexColStart left">
           {/* head */}
           <div className="flexStart head">
             <span className="primaryText">{property?.title}</span>
             <span className="orangeText" style={{ fontSize: "1.5rem" }}>
               $ {property?.price}
             </span>
           </div>

           {/* facilities */}
           <div className="flexStart facilities">
             {/* bathrooms */}
             <div className="flexStart facility">
               <FaShower size={20} color="#1F3E72" />
               <span>{property?.facilities?.bathrooms} Bathrooms</span>
             </div>

             {/* parkings */}
             <div className="flexStart facility">
               <AiTwotoneCar size={20} color="#1F3E72" />
               <span>{property?.facilities.parkings} Parking</span>
             </div>

             {/* rooms */}
             <div className="flexStart facility">
               <MdMeetingRoom size={20} color="#1F3E72" />
               <span>{property?.facilities.bedrooms} Room/s</span>
             </div>
           </div>

           {/* description */}

           <span className="secondaryText" style={{ textAlign: "justify" }}>
             {property?.description}
           </span>

           {/* address */}

           <div className="flexStart" style={{ gap: "1rem" }}>
             <MdLocationPin size={25} />
             <span className="secondaryText">
               {property?.address}{" "}
               {property?.city}{" "}
               {property?.country}
             </span>
           </div>

           {/* booking button */}
           {/* {bookings?.map((booking) => booking.id).includes(id) ? (
             <>
               <Button
                 variant="outline"
                 w={"100%"}
                 color="red"
                 onClick={() => cancelBooking()}
                 disabled={cancelling}
               >
                 <span>Cancel booking</span>
               </Button>
               <span>
                 Your visit already booked for date{" "}
                 {bookings?.filter((booking) => booking?.id === id)[0].date}
               </span>
             </>
           ) : (
             <button
               className="button"
               onClick={() => {
                 validateLogin() && setModalOpened(true);
               }}
             >
               Book your visit
             </button>
           )}

           <BookingModal
             opened={modalOpened}
             setOpened={setModalOpened}
             propertyId={id}
             email={user?.email}
           /> */}
           <button className="button">booking ur visit</button>
          
         </div>

         {/* right side */}
         <div className="w-3/4">
            <Map
              address={property?.address}
              city={property?.city}
              country={property?.country}
            />
          </div>
       </div>
     </div>
   </div>
  );
};

export default PropertyDetails;
