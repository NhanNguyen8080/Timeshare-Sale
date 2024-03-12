import React, { useState } from "react";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faFilter } from '@fortawesome/free-solid-svg-icons';
import { HiLocationMarker } from "react-icons/hi";
import { Link } from "react-router-dom";
import { Modal  } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css';

const SearchBar = ({ filter, setFilter }) => {
  const [showModal, setShowModal] = useState(false);
  const [showDropdown, setShowDropdown] = useState(false);

  const handleInputClick = () => {
    setShowDropdown(!showDropdown);
  };

  const handleModalShow = () => {
    setShowModal(true);
  };

  const handleModalClose = () => {
    setShowModal(false);
  };
  return (
    <div className=" ">
      <div className="flex  rounded-lg p-2 w-full   items-center space-x-4">
      <input
        className=" bg-white rounded-xl p-2 h-16 w-3/4 drop-shadow-lg"
        placeholder="Search by title/city/country..."
        type="text"
        value={filter}
        onChange={(e) => setFilter(e.target.value)}
        onClick={handleInputClick}
      />

      <button
        className="bg-emerald-400 drop-shadow-lg p-2 text-white hover:-translate-y-1 hover:scale-110  duration-300  font-bold rounded-xl"
        onClick={handleModalShow}
      >
        <FontAwesomeIcon className="p-3 text-2xl"
          icon={faFilter} />
      </button>
      </div>
      {showDropdown && (
        <div className="bg-white relative rounded-xl p-2 space-y-10 h-fit w-3/4 drop-shadow-lg">
        <div >
          <div className="py-1">
            <div>Trending Search</div>
            <div
              className="cursor-pointer px-4 py-2 hover:bg-gray-200"
    
            >
              Trending
            </div>
            
          </div>
        </div>
      </div>
      )}
      <Modal show={showModal} onHide={handleModalClose}>
        <Modal.Header >
          <Modal.Title>
            <input
              className=" bg-white rounded-xl p-2 h-16 w-3/4 drop-shadow-lg"
              placeholder="Search by title/city/country..."
              type="text"
              value={filter}
              onChange={(e) => setFilter(e.target.value)}
            />
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          search filter

        </Modal.Body>
      </Modal>
    </div>
  );
};

export default SearchBar;
