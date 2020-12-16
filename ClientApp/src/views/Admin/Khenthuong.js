﻿import React from 'react';
import {
    Card,
    CardHeader,
    CardBody,
    CardTitle,
    CardFooter,
    Table,
    Row,
    Col,
    Button,
    Modal,
    ModalHeader,
    ModalFooter,
    ModalBody,
    Input, Label, Form, FormGroup, Alert
} from "reactstrap";
import axios from 'axios';
import moment from 'moment';
import Search from 'components/Search';
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import SweetAlert from 'react-bootstrap-sweetalert';
import Pagination from "react-js-pagination";

class Khenthuong extends React.Component {

    constructor(props) {

        super(props);
        this.state = {
            vc: [],
            vcxssource: [],
            vcgioisource: [],
            vctbsource: [],
            vcyeusource: [],
            showAlert: false,
            confirm: false,
            activePage: 1,
           
          user: JSON.parse(localStorage.getItem('user')),
          
            vcgioi: [],
            vcxs: [],
            vctb: [],
            vcyeu:[],
            quyen: [],
            chucnang:[],
            valueSearch: '',
            errors: ''
        }
      
   
        
    }



    //load
    componentDidMount() {

        //hien thi danh sach
        axios.get('/Vienchucs/vcgioi/')
            .then((res) => this.setState({
                vcgioisource: res.data,
                vcgioi: res.data,
            })
        );
        axios.get('/Vienchucs/vcxs/')
            .then((res) => this.setState({
                vcxs: res.data,
                vcxssource: res.data,
            })
        );
        axios.get('/Vienchucs/vctb/')
            .then((res) => this.setState({
                vctb: res.data,
                vctbsource: res.data,
            })
            );
        axios.get('/quyens/')
            .then((res) => this.setState({
                quyen: res.data,
               
            })
        );
        axios.get('/Vienchucs/vcyeu/')
            .then((res) => this.setState({
                vcyeu: res.data,
                vcyeusource: res.data,
            })
            );
        axios.get('/chucnangs/')
            .then((res) => this.setState({
                chucnang: res.data,
                
            })
        );
     
        
    }
    //phan trang
    handlePageChange(pageNumber) {
        console.log(`active page is ${pageNumber}`);
        this.setState({ activePage: pageNumber });
    }
    //search
    vcxsSearch = (search) => {

        let sourceArray = this.state.vcxssource;

        let newArray = [];
        if (search.length <= 0) {
            newArray = sourceArray;
        } else {

            console.log(search);
            for (let item of sourceArray) {

                if (item.mavienchuc.toLowerCase().indexOf(search.toLowerCase()) > -1 || item.hoten.toLowerCase().indexOf(search.toLowerCase()) > -1 || item.tenchucvu.toLowerCase().indexOf(search.toLowerCase()) > -1 || item.tenbomon.toLowerCase().indexOf(search.toLowerCase()) > -1) {
                    newArray.push(item);
                }
            }

        }

        this.setState({
            vcxs: newArray,
            valueSearch: search
        });
    }
    vcgioiSearch = (search) => {

        let sourceArray = this.state.vcgioisource;

        let newArray = [];
        if (search.length <= 0) {
            newArray = sourceArray;
        } else {

            console.log(search);
            for (let item of sourceArray) {

                if (item.mavienchuc.toLowerCase().indexOf(search.toLowerCase()) > -1 || item.hoten.toLowerCase().indexOf(search.toLowerCase()) > -1 || item.tenchucvu.toLowerCase().indexOf(search.toLowerCase()) > -1 || item.tenbomon.toLowerCase().indexOf(search.toLowerCase()) > -1) {
                    newArray.push(item);
                }
            }

        }

        this.setState({
            vcgioi: newArray,
            valueSearch: search
        });
    }
    vctbSearch = (search) => {

        let sourceArray = this.state.vctbsource;

        let newArray = [];
        if (search.length <= 0) {
            newArray = sourceArray;
        } else {

            console.log(search);
            for (let item of sourceArray) {

                if (item.mavienchuc.toLowerCase().indexOf(search.toLowerCase()) > -1 || item.hoten.toLowerCase().indexOf(search.toLowerCase()) > -1 || item.tenchucvu.toLowerCase().indexOf(search.toLowerCase()) > -1 || item.tenbomon.toLowerCase().indexOf(search.toLowerCase()) > -1) {
                    newArray.push(item);
                }
            }

        }

        this.setState({
            vctb: newArray,
            valueSearch: search
        });
    }
    vcyeuSearch = (search) => {

        let sourceArray = this.state.vcyeusource;

        let newArray = [];
        if (search.length <= 0) {
            newArray = sourceArray;
        } else {

            console.log(search);
            for (let item of sourceArray) {

                if (item.mavienchuc.toLowerCase().indexOf(search.toLowerCase()) > -1 || item.hoten.toLowerCase().indexOf(search.toLowerCase()) > -1 || item.tenchucvu.toLowerCase().indexOf(search.toLowerCase()) > -1 || item.tenbomon.toLowerCase().indexOf(search.toLowerCase()) > -1) {
                    newArray.push(item);
                }
            }

        }

        this.setState({
            vcyeu: newArray,
            valueSearch: search
        });
    }
    
    //render
    render() {
        
        const { vcgioi,vctb,vcxs,vcyeu } = this.state;
       
        const { user, quyen, chucnang } = this.state;

        let rules = [];
        quyen.forEach((e) => {
            if (e.machucvu.trim() === user.machucvu.trim())
                rules.push(e.machucnang);
        });
        const name = "Quản lý bộ môn";
        const name1 = "Quản lý khoa";
        let cns = [];
        let cn = [];
        chucnang.forEach((x) => {
            if (x.tenchucnang.toLowerCase() === name1.toLowerCase())
                cn.push(x.machucnang);
        });
        chucnang.forEach((x) => {
            if (x.tenchucnang.toLowerCase() === name.toLowerCase() )
                cns.push(x.machucnang);
        });
        return (
            <>

                <div className="content">

                    <Row>
                        <Col md="12">

                            <Card>
                                <CardHeader>

                                    <CardTitle tag="h4"><p style={{ color: '#E86307   ', fontSize: '30px', paddingLeft: '300px' }}><b> DANH SÁCH KẾT QUẢ CÁC VIÊN CHỨC</b> </p></CardTitle>
                                    <CardTitle>
                                        
                                    </CardTitle>

                                   
                                </CardHeader>
                                <Tabs>
                                    <TabList>


                                        <Tab>Hoàn thành xuất sắc</Tab>
                                        <Tab>Hoàn thành tốt</Tab>
                                        <Tab>Hoàn thành</Tab>
                                    <Tab>Không hoàn thành</Tab>

                                    </TabList>

                                    <TabPanel>
                                        
                                        <CardBody>
                                            
                                            <Table className="table table-hover">
                                                
                                                <thead className="text-primary">
                                                    <tr>
                                                        <td colSpan="7">
                                                        <Search
                                                            valueSearch={this.state.valueSearch}
                                                                handleSearch={this.vcxsSearch} />
                    </td>
                                                  </tr>
                                            <tr>
                                                <th>STT</th>

                                                <th>Mã số</th>
                                                <th>Họ tên</th>
                                                <th>Giới tính</th>
                                                <th>Chức danh</th>
                                                <th>Chức vụ</th>
                                                <th>Bộ môn</th>

                                            
                                            </tr>
                                          
                                        </thead>
                                        <tbody>
                                            {
                                                vcxs.map((emp, index) => {
                                                    return (
                                                        <tr key={emp.mavienchuc}>
                                                            <td>{index + 1}</td>
                                                            <td>{emp.mavienchuc}</td>
                                                            <td>{emp.hoten}</td>
                                                            <td>{emp.gioitinh ? 'Nam' : 'Nữ'}</td>
                                                            <td>{emp.tenchucdanh}</td>
                                                            <td>{emp.tenchucvu}</td>
                                                            <td>{emp.tenbomon}</td>
                                             
                                                        </tr>
                                                       
                                                    )
                                                })
                                                    }
                                                    <b> Tổng cộng: {vcxs.length} </b>

                                        </tbody>
                                    </Table>
                                        </CardBody>

                                    </TabPanel>
                                    <TabPanel>
                                        <CardBody>
                                            <Table className="table table-hover">
                                                <thead className="text-primary">
                                                    <tr>
                                                        <td colSpan="7">
                                                            <Search
                                                                valueSearch={this.state.valueSearch}
                                                                handleSearch={this.vcgioiSearch} />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>STT</th>

                                                        <th>Mã số</th>
                                                        <th>Họ tên</th>
                                                        <th>Giới tính</th>
                                                        <th>Chức danh</th>
                                                        <th>Chức vụ</th>
                                                        <th>Bộ môn</th>


                                                    </tr>

                                                </thead>
                                                <tbody>
                                                    {
                                                        vcgioi.map((emp, index) => {
                                                            return (
                                                                <tr key={emp.mavienchuc}>
                                                                    <td>{index + 1}</td>
                                                                    <td>{emp.mavienchuc}</td>
                                                                    <td>{emp.hoten}</td>
                                                                    <td>{emp.gioitinh ? 'Nam' : 'Nữ'}</td>
                                                                    <td>{emp.tenchucdanh}</td>
                                                                    <td>{emp.tenchucvu}</td>
                                                                    <td>{emp.tenbomon}</td>

                                                                </tr>

                                                            )
                                                        })
                                                    }
                                                    <b> Tổng cộng: {vcgioi.length} </b>

                                                </tbody>
                                            </Table>
                                        </CardBody>

                                    </TabPanel>
                                    <TabPanel>
                                        <CardBody>
                                            <Table className="table table-hover">
                                                <thead className="text-primary">
                                                    <tr>
                                                        <td colSpan="7">
                                                            <Search
                                                                valueSearch={this.state.valueSearch}
                                                                handleSearch={this.vctbSearch} />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>STT</th>

                                                        <th>Mã số</th>
                                                        <th>Họ tên</th>
                                                        <th>Giới tính</th>
                                                        <th>Chức danh</th>
                                                        <th>Chức vụ</th>
                                                        <th>Bộ môn</th>


                                                    </tr>

                                                </thead>
                                                <tbody>
                                                    {
                                                        vctb.map((emp, index) => {
                                                            return (
                                                                <tr key={emp.mavienchuc}>
                                                                    <td>{index + 1}</td>
                                                                    <td>{emp.mavienchuc}</td>
                                                                    <td>{emp.hoten}</td>
                                                                    <td>{emp.gioitinh ? 'Nam' : 'Nữ'}</td>
                                                                    <td>{emp.tenchucdanh}</td>
                                                                    <td>{emp.tenchucvu}</td>
                                                                    <td>{emp.tenbomon}</td>

                                                                </tr>

                                                            )
                                                        })
                                                    }
                                                    <b> Tổng cộng: {vctb.length} </b>

                                                </tbody>
                                            </Table>
                                        </CardBody>

                                    </TabPanel>
                                    <TabPanel>
                                        <CardBody>
                                            <Table className="table table-hover">
                                                <thead className="text-primary">
                                                    <tr>
                                                        <td colSpan="7">
                                                            <Search
                                                                valueSearch={this.state.valueSearch}
                                                                handleSearch={this.vcyeuSearch} />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>STT</th>

                                                        <th>Mã số</th>
                                                        <th>Họ tên</th>
                                                        <th>Giới tính</th>
                                                        <th>Chức danh</th>
                                                        <th>Chức vụ</th>
                                                        <th>Bộ môn</th>


                                                    </tr>

                                                </thead>
                                                <tbody>
                                                    {
                                                        vcyeu.map((emp, index) => {
                                                            return (
                                                                <tr key={emp.mavienchuc}>
                                                                    <td>{index + 1}</td>
                                                                    <td>{emp.mavienchuc}</td>
                                                                    <td>{emp.hoten}</td>
                                                                    <td>{emp.gioitinh ? 'Nam' : 'Nữ'}</td>
                                                                    <td>{emp.tenchucdanh}</td>
                                                                    <td>{emp.tenchucvu}</td>
                                                                    <td>{emp.tenbomon}</td>

                                                                </tr>

                                                            )
                                                        })
                                                    }
                                                    <b> Tổng cộng: {vcyeu.length} </b>

                                                </tbody>
                                            </Table>
                                        </CardBody>

                                    </TabPanel>
                                </Tabs>
                                <CardFooter style={{ paddingLeft: '450px' }}>
                                    <Pagination
                                        itemClass="page-item"
                                        linkClass="page-link"
                                        activePage={this.state.activePage}
                                        itemsCountPerPage={5}
                                        pageRangeDisplayed={5}
                                        totalItemsCount={vcxs.length}
                                      
                                        onChange={this.handlePageChange.bind(this)}
                                    /> </CardFooter>
                            </Card>
                        </Col>

                    </Row>
                </div>
            </>
        );

    }
}

export default Khenthuong;