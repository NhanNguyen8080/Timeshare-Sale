import React, { useEffect, useState } from "react";
import { Card, Col, Row, Statistic, InputNumber } from "antd";
import CountUp from "react-countup";
import PieChart from "../Charts/PieChart";
import {
  getContract,
  getBooking,
  getContractByMonth,
  getCustomer,
  getInvestor,
  getProperty,
  getStaff,
  getPercentagePropertyAvailable,
  getPropertyAvailable,
  getBookingPercent,
} from "../utils/api";
import "./AdminPage.css";
const formatter = (value) => <CountUp end={value} separator="," />;
const AdminPage = () => {
  var currentDate = new Date();
  var currentMonth = currentDate.getMonth() + 1;
  const [contract, setContract] = useState(0);
  const [staff, setStaff] = useState(0);
  const [booking, setBooking] = useState(0);
  const [contractByMonth, setContractByMonth] = useState(0);
  const [customer, setCustomer] = useState(0);
  const [investor, setInvestor] = useState(0);
  const [property, setProperty] = useState(0);
  const [percentagePropertyAvailable, setPercentagePropertyAvailable] =
    useState(0);
  const [propertyAvailable, setPropertyAvailable] = useState(0);
  const [bookingPercent, setBookingPercent] = useState(0);
  const fetchData = async (apiFunction, setterFunction, data = null) => {
    let response = await apiFunction(data);
    setterFunction(response);
  };

  useEffect(() => {
    fetchData(getContract, setContract);
    fetchData(getStaff, setStaff);
    fetchData(getBooking, setBooking, currentMonth);
    fetchData(getContractByMonth, setContractByMonth, currentMonth);
    fetchData(getCustomer, setCustomer);
    fetchData(getInvestor, setInvestor);
    fetchData(getProperty, setProperty);
    fetchData(
      getPercentagePropertyAvailable,
      setPercentagePropertyAvailable,
      currentMonth
    );
    fetchData(getPropertyAvailable, setPropertyAvailable, currentMonth);
    fetchData(getBookingPercent, setBookingPercent, currentMonth);
  }, []);
  const onChange = (value) => {
    console.log("changed", value);
  };
  return (
    <div className="wrap">
      {/* <Row gutter={16}>
        <Col span={4}>
          <InputNumber min={1} max={10} defaultValue={3} onChange={onChange} />
        </Col>
      </Row> */}

      <Row gutter={16}>
        <Col span={4}>
          <Card bordered={false}>
            <Statistic
              title="Revenue"
              value={contractByMonth}
              formatter={formatter}
            />
          </Card>
        </Col>
        <Col span={4}>
          <Card bordered={false}>
            <Statistic
              title="Avaiable Property"
              value={propertyAvailable}
              formatter={formatter}
            />
          </Card>
        </Col>
        <Col span={4}>
          <Card bordered={false}>
            <Statistic
              title="Contract quantity"
              value={contract}
              formatter={formatter}
            />
          </Card>
        </Col>
        <Col span={4}>
          <Card bordered={false}>
            <Statistic
              title="Active Staff"
              value={staff}
              formatter={formatter}
            />
          </Card>
        </Col>
        <Col span={4}>
          <Card bordered={false}>
            <Statistic
              title="Active Investor"
              value={investor}
              formatter={formatter}
            />
          </Card>
        </Col>
        <Col span={4}>
          <Card bordered={false}>
            <Statistic
              title="Active Customer"
              value={customer}
              formatter={formatter}
            />
          </Card>
        </Col>
        <Col span={4}>
          <Card bordered={false}>
            <PieChart
              label="Property available percent"
              data={percentagePropertyAvailable}
            />
          </Card>
        </Col>
        <Col span={4}>
          <Card bordered={false}>
            <PieChart label="Booking percent" data={bookingPercent} />
          </Card>
        </Col>
        <Col span={4}>
          <Card bordered={false}>
            <Statistic
              title="Total Property"
              value={property}
              formatter={formatter}
            />
          </Card>
        </Col>

        <Col span={4}>
          <Card bordered={false}>
            <Statistic
              title="Monthly Booking"
              value={booking}
              formatter={formatter}
            />
          </Card>
        </Col>
      </Row>
      <Row gutter={16}></Row>
    </div>
  );
};

export default AdminPage;
