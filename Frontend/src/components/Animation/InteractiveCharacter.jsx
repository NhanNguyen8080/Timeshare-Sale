import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

function InteractiveCharacter() {
  const [isHappy, setIsHappy] = useState(false);
  const [isCharacterVisible, setIsCharacterVisible] = useState(false);
  const [characterPosition, setCharacterPosition] = useState({ x: 0, y: 0 });
  const navigate = useNavigate();

  const handleMouseEnter = (e) => {
    setIsCharacterVisible(true);
    setCharacterPosition({ x: e.clientX + 20, y: e.clientY + 20 });
  };

  const handleMouseLeave = () => {
    setIsCharacterVisible(false);
  };

  const handleMouseMove = (e) => {
    setCharacterPosition({ x: e.clientX, y: e.clientY });
  };

  const handleButtonClick = () => {
    setIsCharacterVisible(!isCharacterVisible);
    setIsHappy(!isHappy);
    setTimeout(() => {
      navigate("/login")
    }, 1500);

  };

  const handleClick = (e) => {

  };

  const toggleEmotion = () => {
    setIsHappy(!isHappy);
  };

  return (


    <div className=" w-1/6 h-1/6 border-2  rounded-full border-white p-4 bg-white bg-opacity-50 shadow-2xl shadow-gray-700">
      {isHappy ? 
      <p className="cursor-wait text-center justify-center items-center font-pacifico bg-clip-text text-transparent bg-gradient-to-r text-lg from-violet-950 to-cyan-200 font-bold "> Loading ...</p>
        : <p
          className=" font-pacifico text-center justify-center items-center  bg-clip-text text-transparent bg-gradient-to-r from-pink-500 to-violet-500 text-lg font-bold">
          Cuddle me to login :3!
        </p>}

      <img
      
        src={isHappy ? "/assets/gifs/dazaimochi.gif" : "/assets/gifs/meo.gif"}
        alt="Character"
        onClick={handleButtonClick}
        className="cursor-pointer w-1/3 h-1/3 mx-auto justify-center items-center "
      />
      

    </div>


  );
}

export default InteractiveCharacter;
