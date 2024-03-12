import React from 'react';
import { Link } from 'react-router-dom';
// import './fontconfig.css'

const NotFoundPage = () => (

  <div className="bg-scroll justify-center items-center bg-cover bg-center min-h-screen flex "
    style={{ backgroundImage: `url(/images/f1.jpg)` }}>

    <div >
      <div className='relative'>
        <div className='bg-neutral-900 blur-3xl p-20 absolute inset-0 '></div>
        <div className='relative text-white z-10  '>
          <h1 className='flex items-center justify-center text-3xl p-2 font-pacifico'>
            Page not found
          </h1>
          <p>Oops! Looks like you followed a bad link. If you think this is a problem with us, please tell us.
            
          </p>
          <Link to="/" className="flex items-center justify-center   ">
            Go Home
          </Link>
        </div>

      </div>

 



    // </div>


  // </div>
);

export default NotFoundPage;
