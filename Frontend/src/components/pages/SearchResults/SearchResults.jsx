
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getAllProperties } from '../../utils/api';
import PropertyCard from '../../PropertyCard/PropertyCard';

const SearchResults = () => {
  const { filter } = useParams();
  const [results, setResults] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getAllProperties();
        const filteredResults = data.filter(
          (property) =>
            property.title.toLowerCase().includes(filter.toLowerCase()) ||
            property.city.toLowerCase().includes(filter.toLowerCase()) ||
            property.country.toLowerCase().includes(filter.toLowerCase())
        );
        setResults(filteredResults);
      } catch (error) {
        console.error(error);
      }
    };

    fetchData();
  }, [filter]);

  return (
    <div className="p-5 grid grid-cols-4 gap-4">
      {results.map((property) => (
        <PropertyCard key={property.id} property={property} />
      ))}
    </div>
  );
};

export default SearchResults;
