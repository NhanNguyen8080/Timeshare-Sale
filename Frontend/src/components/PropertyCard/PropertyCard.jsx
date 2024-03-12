// import React from "react";
// import './PropertyCard.css'
// import {AiFillHeart} from 'react-icons/ai'
// import {truncate} from 'lodash'
// import { useNavigate } from "react-router-dom";
// // import Heart from "../Heart/Heart";
// const PropertyCard = ({card}) => {

//   const navigate = useNavigate();
//   return (
//     <div className="flexColStart r-card"
//     onClick={()=>navigate(`../properties/${card.id}`)}
//     >
//       {/* <Heart id={card?.id}/> */}
//       <img src={card.image} alt="home" />
//       <span className="secondaryText r-price">
//         <span style={{ color: "orange" }}>$</span>
//         <span>{card.price}</span>
//       </span>
//       <span className="primaryText">{truncate(card.title, {length: 15})}</span>
//       <span className="secondaryText">{truncate(card.description, {length: 80})}</span>
//     </div>
//   );
// };

// export default PropertyCard;
import React from "react";
import { Link } from "react-router-dom";

const PropertyCard = ({ property }) => {
  return (
    
    <div className="">
    <div className="bg-blue-100 hover:bg-emerald-200 shadow-lg p-4 rounded-md">
    <Link to={`/property/${property.id}`}>
      <img src={property.image} alt={property.title} />
      <h2 className="text-lg font-semibold text-blue-800">{property.title}</h2>
      <p className="secondaryText">{property.description}</p>
      <p  className="text-2xl font-bold text-blue-700">Price: ${property.price}</p>
      </Link>
    </div>
    </div>
  );
};

export default PropertyCard;
