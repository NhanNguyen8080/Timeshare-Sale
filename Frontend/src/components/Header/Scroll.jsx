import React, { useEffect, useState } from 'react';

const ScrollToTopButton = ({ targetId }) => {
  const handleScroll = () => {
    const element = document.getElementById(targetId);
    if (element) {
      element.scrollIntoView({ behavior: 'smooth' });
    }
  };

  return (
    <button onClick={handleScroll} >
        Contact
    </button>
  );
};

export default ScrollToTopButton;
