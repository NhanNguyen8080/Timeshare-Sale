import React from "react";
import { Link, NavLink } from "react-router-dom";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faMagnifyingGlass } from '@fortawesome/free-solid-svg-icons';
import './header.css'
import ScrollToTopButton from "./Scroll";

function Header() {
    return (
        <><div className="">
            <div className="bg-black text-white flex space-x-4 relative text-sm p-1">
                <div className=" pl-20">
                    <p>Ho Chi Minh, Viet Nam</p>
                </div>
                <div className="flex absolute space-x-4 inset-y-0 right-20 p-1">
                    <p>+84 123-456-789</p>
                    <p>support@gmail.com</p>
                </div>
            </div>
            <div className="bg-emerald-50 text-black flex justify-between items-center text-sm font-semibold p-1 pr-20">
            <div className="flex space-x-10 pl-20">
          <Link to="/">
            <NavLink to="/">
            
            Home </NavLink></Link>
          <Link to="/">About</Link>
          <Link to="/">Services</Link>
          <Link to="/properties">Properties</Link>
          <Link to="/">Blogs</Link>
          <ScrollToTopButton targetId="contact-us" />
        </div>
                <div className="flex space-x-4  ">
                    <button className="relative">
                        <FontAwesomeIcon className="bg-white p-3 border-emerald-400 border-2 text-emerald-400 rounded-full" icon={faMagnifyingGlass} />
                    </button>
                    <Link to="/login">
                    <button className="bg-emerald-400 p-3 text-black border-2 border-emerald-400 rounded-full ">
                        Get Started
                    </button>
                    </Link>
                </div>
            </div>

        </div>
        <div className="bgCircle">

        </div>
        </>
    )

}

export default Header;
