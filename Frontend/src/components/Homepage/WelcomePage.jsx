import React from "react";
import "./Welcome.css";
import CountUp from "react-countup";
import { motion } from "framer-motion";
import SearchBar from "../SearchBar/SearchBar";

function WelcomePage() {
    return (
        <>
        <section className="">
        <div className="flex items-center justify-center pt-10 space-x-36">
        {/* left side */}
        <div className=" space-y-7 hero-left">
          <div className="hero-title">
            <motion.h1
            initial={{ y: "2rem", opacity: 0 }}
            animate={{ y: 0, opacity: 1 }}
            transition={{
              duration: 2,
              type: "ease-in",
            }}
            >
              Discover A Place  <br />
              you'll love to live
            </motion.h1>
          </div>
          <div className="flexColStart flexhero-des text-lg">
            <span> Homie is a real estate solution that gives you the local scoop about homes.</span>
            <span>Search confidently with your trusted source of homes for sale or rent.</span>
          </div>

          <SearchBar/>

          <div className="flexCenter bg-white p-6 rounded-full w-5/6 drop-shadow-lg space-x-10">
            <div className="flexColCenter stat">
              <span>
                <CountUp start={840} end={900} duration={4} /> <span>+</span>
              </span>
              <span className="text-sm">Premium Product</span>
            </div>

            <div className="flexColCenter stat">
              <span>
                <CountUp start={1950} end={2000} duration={4} /> <span>+</span>
              </span>
              <span className=" text-sm">Happy Customers</span>
            </div>

            <div className="flexColCenter stat">
              <span>
                <CountUp end={150} /> <span>+</span>
              </span>
              <span className="text-sm">New Listings Everyday!</span>
            </div>
          </div>
        </div>

        {/* right side */}
        <div className="flexCenter hero-right">
          <div className="orange-circle" />
          <motion.div
            initial={{ x: "7rem", opacity: 0 }}
            animate={{ x: 0, opacity: 1 }}
            transition={{
              duration: 2,
              type: "ease-in",
            }}
            className="image-container"
          >
            <img src="./images/sydney.jpg" alt="houses" />
          </motion.div>
        </div>
      </div>
    </section>
           

        </>
    );
}


export default WelcomePage;

{/* <div className="flex items-center justify-center h-screen space-x-36">
<div>
    <div className="text-left pl-20 space-y-10">
        <p className="text-7xl font-bold">
            Discover A Place you'll love to live
        </p>
        <p className="text-lg">
            Homie is a real estate solution that gives you the local scoop about homes.
            Search confidently with your trusted source of homes for sale or rent.
        </p>

    </div>
    <div className="pt-20">
        <p className="p-5 bg-white rounded-full w-fit">
            72k+ Happy Customers
        </p>
    </div>
</div>
<div className="items-center justify-center pr-20">
    <img
        src="./images/sydney.jpg"
        alt="Sydney"
        className="w-full rounded-lg"
    />
    <div className="pt-20">
    <p className="p-10 bg-white rounded-full w-fit">
        200+ New Listings Everyday!
        </p>
    </div>
</div>
</div> */}