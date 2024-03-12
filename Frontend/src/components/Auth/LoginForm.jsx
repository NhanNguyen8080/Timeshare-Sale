import React, { useState } from "react";
import { useForm } from "react-hook-form";
import axios from "axios";
import { useDispatch } from "react-redux";
import { Link, useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

import CharacterInteraction from "../Animation/CharacterInteraction";

function LoginForm() {
    // const dispatch = useDispatch();
    // const navigate = useNavigate();
    const { register, handleSubmit, formState: { errors } } = useForm();
    const [isCharacterVisible, setIsCharacterVisible] = useState(false);
    const [characterPosition, setCharacterPosition] = useState({ x: 0, y: 0 });

    const handleMouseEnter = (e) => {
        setIsCharacterVisible(true);
        setCharacterPosition({ x: e.clientX + 20, y: e.clientY + 20 });
    };

    const handleMouseLeave = () => {
        setIsCharacterVisible(false);
    };

    // const onSubmit = (data) => {
    //     const { email, name } = data;

    //     axios
    //         .get("https://64b2547838e74e386d54fa40.mockapi.io/api/v1/user")
    //         .then((response) => {
    //             const users = response.data;
    //             const authenticatedUser = users.find(
    //                 (user) => user.Email === email && user.Name === name
    //             );

    //             if (authenticatedUser) {
    //                 dispatch(login(authenticatedUser));
    //                 toast.success("Login success");
    //               } else {
    //                 toast.error("Invalid email or password");
    //               }
    //             })
    //         .catch((error) => {
    //             console.error("Login failed", error);
    //             toast.error("Error");
    //         });
    // };

    return (
        <div className="bg-scroll bg-cover bg-center min-h-screen flex rounded-lg justify-center items-center opacity-90"
            style={{ backgroundImage: `url(/images/login.jpg)` }}>
            <div className=" rounded-lg w-full md:w-1/3 h-3/4 border-2 border-white bg-white bg-opacity-40 p-4 shadow-lg shadow-gray-500/50 no-gutters">
            <div className=" justify-center items-center" >
                    <CharacterInteraction />
                </div>
                <h2 className=" text-2xl text-center bg-clip-text text-transparent bg-gradient-to-r from-black to-emerald-500 font-bold">
                    Login
                </h2>
                <form onSubmit={handleSubmit()}>
                    <input
                        type="text"
                        placeholder="Email"
                        {...register("email", { required: true, pattern: /^\S+@\S+$/i })}
                        className="w-full md:w-3/4 mx-2 md:mx-16 px-2 py-2 border-2 caret-violet-500 border-violet-500 rounded-lg"
                    />
                    {errors.email && <p className="text-teal-950">Email is required</p>}
                    <input
                        type="password"
                        placeholder="Password"
                        {...register("name", { required: true })}
                        className="w-full md:w-3/4 my-2 md:my-4 mx-2 md:mx-16 px-2 py-2 border-2 caret-violet-500 border-violet-500 rounded-lg"
                    />
                    {errors.name && <p className="text-teal-950">Password is required</p>}
                    <button
                        type="submit"
                        className="cursor-pointer w-fit md:w-3/4 my-4 mx-2 md:mx-16 transition ease-in-out bg-emerald-700 hover:-translate-y-1 hover:scale-110 hover:bg-emerald-800 duration-300 text-white font-bold py-2 rounded-lg"
                        onMouseEnter={handleMouseEnter}
                        onMouseLeave={handleMouseLeave}
                    >
                        Login
                    </button>
                </form>
                <div className="font-pacifico">
                    <Link to="/register">
                        <p>Register?</p>
                    </Link>
                </div>

                {isCharacterVisible && (
                    <div
                    className="absolute"
                    style={{
                        left: characterPosition.x,
                        top: characterPosition.y,
                    }}
                >
                        <img
                            src="/assets/gifs/giphy.gif"
                            alt="Character"
                            
                            className="max-w-sm max-h-10"
                        />
                    </div>
                )}
            </div>
        </div>
    );
}

export default LoginForm;
