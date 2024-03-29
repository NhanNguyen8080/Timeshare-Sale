import React from "react";
import { BrowserRouter, Router, Route, Routes } from "react-router-dom";
import Homepage from "./components/Homepage/Homepage";
import NotFoundPage from "./components/NotFoundPage/NotFoundPage";
import LoginForm from "./components/Auth/LoginForm";
import RegisterForm from "./components/Auth/RegisterForm";
import Properties from "./components/pages/Properties/Properties";
import { ToastContainer } from "react-toastify";
import Header from "./components/Header/Header";
import PropertyDetails from "./components/pages/Property/PropertyDetails";
import SearchResults from "./components/pages/SearchResults/SearchResults";
import AdminPage from "./components/AdminPage/AdminPage";

function App() {
  const isAdmin = window.location.pathname.startsWith("/admin");
  return (
    <div>
      <BrowserRouter>
        {!isAdmin && <Header />}
        <Routes>
          <Route path="/" element={<Homepage />} />
          <Route path="/login" element={<LoginForm />} />
          <Route path="/register" element={<RegisterForm />} />
          {/* <Route path="/search/:filter" element={<SearchResults />} /> */}
          <Route path="/properties" element={<Properties />} />
          <Route path="/property/:id" element={<PropertyDetails />} />
          <Route path="*" element={<NotFoundPage />} />
          <Route path="/admin" element={<AdminPage />} />
        </Routes>
      </BrowserRouter>
      <ToastContainer />
    </div>
  );
}

export default App;
