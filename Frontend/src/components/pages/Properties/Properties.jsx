import React, { useEffect, useState } from "react";
import { PuffLoader } from "react-spinners";
import SearchBar from "../../SearchBar/SearchBar";
import "./Properties.css";
import useProperties from "../../hooks/useProperties";
import { getAllProperties } from "../../utils/api";
import PropertyCard from "../../PropertyCard/PropertyCard";

const Properties = () => {
  const [properties, setProperties] = useState([]);
  const [filter, setFilter] = useState("");

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getAllProperties();
        setProperties(data);
      } catch (error) {
        console.error(error);
      }
    };

    fetchData();
  }, []);

  return (
    <div className="property-list">
      <SearchBar filter={filter} setFilter={setFilter} />
      <div className="p-5 grid grid-cols-4 gap-4">
      {properties
      .filter(
        (property) =>
          property.title.toLowerCase().includes(filter.toLowerCase()) ||
          property.city.toLowerCase().includes(filter.toLowerCase()) ||
          property.country.toLowerCase().includes(filter.toLowerCase())
      )
      .map((property) => (
        
        <PropertyCard key={property.id} property={property} />
      ))}
    </div>
    </div>
  );
};

export default Properties;
