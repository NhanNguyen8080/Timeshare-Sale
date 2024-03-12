import React, { useState } from "react";
import { useForm } from "react-hook-form";
import axios from "axios";
import { useDispatch } from "react-redux";
import { useNavigate, Link } from "react-router-dom";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import CharacterInteraction from "../Animation/CharacterInteraction";
import { Modal, Button } from "react-bootstrap"; 

function RegisterForm({ onCloseModal }) {
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

    // const onSubmit = async (data) => {
    //     const { email,name, password } = data;
    //     try {
    //         const response = await axios.post(`http://127.0.0.1:1880/user`, {
    //             Email: email,
    //             Name: name,
    //             Password: password,
    //             Role: 0
    //         });
    //         toast.success('Registration successful!');
    //         console.log('Registration successful: ', response);
    //         navigate('/login');
    //         onCloseModal();
    //     } catch (error) {
    //         console.error('Error during registration:', error);
    //         toast.error('Registration failed! ' + error.response.data);
    //     }
    // };


    return (
  
        <div className="bg-scroll bg-cover bg-center min-h-screen flex rounded-lg justify-center items-center opacity-90"
            style={{ backgroundImage: `url(/images/login.jpg)` }}>
            <div className=" rounded-lg w-full md:w-1/3 h-3/4 border-2 border-white bg-white bg-opacity-40 p-4 shadow-lg shadow-gray-500/50">
            <div className=" justify-center items-center" >
                    <CharacterInteraction />
                </div>
                <h2 className=" text-2xl text-center bg-clip-text text-transparent bg-gradient-to-r from-pink-950 to-violet-500 font-bold">
                    Register
                </h2>
                <form  className="justify-center items-center place-content-center" onSubmit={handleSubmit()}>
                    <input
                        type="text"
                        placeholder="Email"
                        {...register("email", { required: true, pattern: /^\S+@\S+$/i })}
                        className="w-4/5  my-2 md:my-1 mx-2 md:mx-16 px-2 py-2 border-2 caret-violet-500 border-violet-500 rounded"
                    />
                    {errors.email && <p className="text-teal-950">Email is required and must be valid</p>}
                    <input
                        type="text"
                        placeholder="Name"
                        {...register("name", { required: true })}
                        className="w-4/5   my-2 md:my-1 mx-2 md:mx-16 px-2 py-2 border-2 caret-violet-500 border-violet-500 rounded"
                    />
                    {errors.email && <p className="text-teal-950">Name is required and must be valid</p>}

                    <input
                        type="password"
                        placeholder="Password"
                        {...register("password", { required: true })}
                        className="w-4/5  my-2 md:my-1 mx-2 md:mx-16 px-2 py-2 border-2 caret-violet-500 border-violet-500 rounded"
                    />
                    {errors.name && <p className="text-teal-950">Password is required</p>}

{/* 
                    <input
                        type="password"
                        placeholder="Confirm Password"
                        {...register("confirmPassword", {
                            required: true,
                            validate: (value) => value === data.password,
                        })}
                        className="w-full md:w-3/4 my-2 md:my-4 mx-2 md:mx-16 px-2 caret-violet-500 py-1 border-2 border-violet-500 rounded"
                    />
                    {errors.confirmPassword && <p className="text-teal-950">Passwords do not match</p>} */}



<button
                        type="submit"
                        className="cursor-pointer w-fit md:w-3/4 my-4 mx-2 md:mx-16 transition ease-in-out bg-emerald-700 hover:-translate-y-1 hover:scale-110 hover:bg-emerald-800 duration-300 text-white font-bold py-2 rounded-lg"
                        onMouseEnter={handleMouseEnter}
                        onMouseLeave={handleMouseLeave}
                    >
                        Register
                    </button>
                </form>
                {isCharacterVisible && (
                    <div className="absolute" style={{ left: characterPosition.x, top: characterPosition.y }}>
                        <img src="/assets/gifs/giphy.gif" alt="Character" style={{ maxWidth: "50px", maxHeight: "50px" }} />
                    </div>
                )}
                <div>
                    <Link to="/login">
                        <p>Already have an account? Login here.</p>
                    </Link>
                </div>
            </div>
        </div>


    );
}

export default RegisterForm;

