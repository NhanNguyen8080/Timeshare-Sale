import React from "react";
import { Card, Col, Row, Statistic } from "antd";
import CountUp from "react-countup";
import PieChart from "../Charts/PieChart";
const formatter = (value) => <CountUp end={value} separator="," />;
const AdminPage = () => {
  return (
    <>
      <Row gutter={16}>
        <Col span={4}>
          <Card bordered={false}>
            <Statistic title="Revenue" value={112493} formatter={formatter} />
          </Card>
        </Col>
        <Col span={4}>
          <Card bordered={false}>
            <Statistic
              title="Active Property"
              value={112493}
              formatter={formatter}
            />
          </Card>
        </Col>
        <Col span={4}>
          <Card bordered={false}>
            <Statistic
              title="Contract quantity"
              value={112493}
              formatter={formatter}
            />
          </Card>
        </Col>
        <Col span={4}>
          <Card bordered={false}>
            <Statistic
              title="Active Staff"
              value={112493}
              formatter={formatter}
            />
          </Card>
        </Col>
        <Col span={4}>
          <Card bordered={false}>
            <Statistic
              title="Active Investor"
              value={112493}
              formatter={formatter}
            />
          </Card>
        </Col>
        <Col span={4}>
          <Card bordered={false}>
            <Statistic
              title="Active Customer"
              value={112493}
              formatter={formatter}
            />
          </Card>
        </Col>
        <Col span={8}>
          <Card bordered={false}>
            <PieChart />
          </Card>
        </Col>
      </Row>
      <Row gutter={16}></Row>
    </>
  );
};

export default AdminPage;
