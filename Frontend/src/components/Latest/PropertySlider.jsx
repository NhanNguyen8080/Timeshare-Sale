import React, { useEffect, useState } from "react";
import Slider from "react-slick";
import PropertyCard from "../PropertyCard/PropertyCard";

const PropertySlider = ({ properties, propertyCardStyle }) => {
  const [visibleProperties, setVisibleProperties] = useState([]);

  useEffect(() => {
    setVisibleProperties(properties.slice(0, 8));
  }, [properties]);
  console.log(visibleProperties);
  const settings = {
    dots: true,
    infinite: true,
    speed: 500,
    slidesToShow: 4,
    slidesToScroll: 1,
  };

  return (
    <div className="property-slider text-black">
      <Slider {...settings}>
        {visibleProperties.map((property) => (
          <div key={property.id}>
            <PropertyCard property={property} />
          </div>
        ))}
      </Slider>
    </div>
  );
};

export default PropertySlider;
