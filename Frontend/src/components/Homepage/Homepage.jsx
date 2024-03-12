import React, { useEffect, useState } from "react";
import WelcomePage from "./WelcomePage";
import Footer from "../Footer/Footer";
import Contact from "../Contact/Contact";
import PropertySlider from "../Latest/PropertySlider";
import { getAllProperties } from "../utils/api";
import GetStarted from "../GetStarted/GetStarted";

function Homepage() {
  const [properties, setProperties] = useState([]);

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
    <>
      <WelcomePage />
      {/* <PropertySlider properties={properties}  /> */}
      <Contact />
      <GetStarted/>
      <Footer />
    </>
  );
}

export default Homepage;
