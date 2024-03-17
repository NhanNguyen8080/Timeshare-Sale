// api.js
import axios from "axios";
import { toast } from "react-toastify";

export const api = axios.create({
  baseURL: "https://65edf5fb08706c584d9af0ab.mockapi.io/api/v1",
});

export const getAllProperties = async () => {
  try {
    const response = await api.get("/properties", {
      timeout: 10 * 1000,
    });

    if (response.status === 400 || response.status === 500) {
      throw response.data;
    }
    return response.data;
  } catch (error) {
    toast.error("Something went wrong");
    throw error;
  }
};

// export const getProperty = async (id) => {
//   try {
//     const response = await api.get(`/residency/${id}`, {
//       timeout: 10 * 1000,
//     });

//     if (response.status === 400 || response.status === 500) {
//       throw response.data;
//     }
//     return response.data;
//   } catch (error) {
//     toast.error("Something went wrong");
//     throw error;
//   }
// };

// export const createUser = async (email, token) => {
//   try {
//     await api.post(
//       `/user/register`,
//       { email },
//       {
//         headers: {
//           Authorization: `Bearer ${token}`,
//         },
//       }
//     );
//   } catch (error) {
//     toast.error("Something went wrong, Please try again");
//     throw error;
//   }
// };

// export const bookVisit = async (date, propertyId, email, token) => {
//   try {
//     await api.post(
//       `/user/bookVisit/${propertyId}`,
//       {
//         email,
//         id: propertyId,
//         date: dayjs(date).format("DD/MM/YYYY"),
//       },
//       {
//         headers: {
//           Authorization: `Bearer ${token}`,
//         },
//       }
//     );
//   } catch (error) {
//     toast.error("Something went wrong, Please try again");
//     throw error;
//   }
// };

// export const removeBooking = async (id, email, token) => {
//   try {
//     await api.post(
//       `/user/removeBooking/${id}`,
//       {
//         email,
//       },
//       {
//         headers: {
//           Authorization: `Bearer ${token}`,
//         },
//       }
//     );
//   } catch (error) {
//     toast.error("Something went wrong, Please try again");

//     throw error;
//   }
// };

// export const toFav = async (id, email, token) => {
//   try {
//     await api.post(
//       `/user/toFav/${id}`,
//       {
//         email,
//       },
//       {
//         headers: {
//           Authorization: `Bearer ${token}`,
//         },
//       }
//     );
//   } catch (e) {
//     throw e;
//   }
// };

// export const getAllFav = async (email, token) => {
//   if(!token) return
//   try{

//     const res = await api.post(
//       `/user/allFav`,
//       {
//         email,
//       },
//       {
//         headers: {
//           Authorization: `Bearer ${token}`,
//         },
//       }
//     );

//     return res.data["favResidenciesID"]

//   }catch(e)
//   {
//     toast.error("Something went wrong while fetching favs");
//     throw e
//   }
// }

// export const getAllBookings = async (email, token) => {

//   if(!token) return
//   try {
//     const res = await api.post(
//       `/user/allBookings`,
//       {
//         email,
//       },
//       {
//         headers: {
//           Authorization: `Bearer ${token}`,
//         },
//       }
//     );
//     return res.data["bookedVisits"];

//   } catch (error) {
//     toast.error("Something went wrong while fetching bookings");
//     throw error
//   }
// }

// export const createResidency = async (data, token) => {
//   console.log(data)
//   try{
//     const res = await api.post(
//       `/residency/create`,
//       {
//         data
//       },
//       {
//         headers: {
//           Authorization: `Bearer ${token}`,
//         },
//       }
//     )
//   }catch(error)
//   {
//     throw error
//   }
// }
let apiURL = "https://localhost:7171/api";
async function customApiCall(url, method = "GET", data = null, headers = {}) {
  try {
    const response = await fetch(url, {
      method,
      headers: {
        "Content-Type": "application/json",
        ...headers, // Merge custom headers
      },
      body: data ? JSON.stringify(data) : null,
    });

    if (!response.ok) {
      throw new Error(`API request failed with status ${response.status}`);
    }

    const responseData = await response.json();
    return responseData;
  } catch (error) {
    console.error("Error fetching data:", error);
    return null;
  }
}

export async function getContract() {
  const apiUrl = apiURL + "/Contract";
  const data = await customApiCall(apiUrl);
  return data;
}

export async function getContractByMonth(month) {
  const apiUrl = apiURL + `/Contract/total/${month}`;
  const data = await customApiCall(apiUrl);
  return data;
}
export async function getCustomer() {
  const apiUrl = apiURL + "/Customer";
  const data = await customApiCall(apiUrl);
  return data;
}
export async function getInvestor() {
  const apiUrl = apiURL + "/Investor";
  const data = await customApiCall(apiUrl);
  return data;
}
export async function getProperty() {
  const apiUrl = apiURL + "/Property";
  const data = await customApiCall(apiUrl);
  return data;
}
export async function getPropertyAvailable(month) {
  const apiUrl = apiURL + `/Property/Available/${month}`;
  const data = await customApiCall(apiUrl);
  return data;
}

export async function getPercentagePropertyAvailable(month) {
  const apiUrl = apiURL + `/Property/Available/Percent/${month}`;
  const data = await customApiCall(apiUrl);
  return data * 100;
}

export async function getBooking(month) {
  const apiUrl = apiURL + `/Property/Booking/${month}`;
  const data = await customApiCall(apiUrl);
  return data;
}

export async function getBookingPercent(month) {
  const apiUrl = apiURL + `/Property/Booking/Percent/${month}`;
  console.log(apiURL);
  const data = await customApiCall(apiUrl);
  console.log(data);
  return data;
}

export async function getStaff() {
  const apiUrl = apiURL + "/Staff";
  const data = await customApiCall(apiUrl);
  return data;
}

export async function search(keyword) {
  const apiUrl = apiURL + "/TimeShare/search";
  const data = await customApiCall(apiUrl, "POST", { keyword: keyword });
  return data;
}
// data type:
// [ {
//   "bookings": ,
//   "bookmarkTimeShares": [],
//   "propertyId": ,
//   "propertyName": ,
//   "propertyType": ,
//   "country": ,
//   "address": ,
//   "price": ,
//   "isAvailable": ,
//   "description": ,
//   "lastUpdate": ,
//   "images": ,
//   "ownerId":
// }]
