import React, { useState, useEffect } from "react";

function CharacterInteraction() {


  const [randomImage, setRandomImage] = useState("");
  const [audioPlayed, setAudioPlayed] = useState(false);

  const playSoundEffect = () => {
    if (audioPlayed) {
      setAudioPlayed(false);
    } else {
      const audioElement = new Audio("/assets/sounds/rickroll.mp3");
      audioElement.play();
      setAudioPlayed(true);
    }
  };

  useEffect(() => {
    if (audioPlayed) {
      setRandomImage("/assets/gifs/rickroll.gif");
    } else {
      setRandomImage("/assets/gifs/dazaimochi.gif");
     
    }
  }, [audioPlayed]);

  return (
    <div className="cursor-pointer w-20 h-20 mx-auto justify-center items-center">
      <img
        onClick={playSoundEffect}
        src={randomImage}
        alt="Character"
        className="w-full h-full"
      />
    </div>
  );
}

export default CharacterInteraction;
