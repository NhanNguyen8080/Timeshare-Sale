import React from "react";
import { useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faRightFromBracket} from '@fortawesome/free-solid-svg-icons'

const Logout = () => {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const handleLogout = () => {
    // dispatch(logout());
    navigate("/");
  };
  

  return (
    <li onClick={handleLogout} className="flex items-center w-full p-2  text-zinc-900 transition duration-75 rounded-lg group hover:bg-zinc-300">
      <FontAwesomeIcon className="pr-2  "  icon={faRightFromBracket} />
       Logout
    </li>
  );
};

export default Logout;

