import React from 'react';
import axios from 'axios';
import { useEffect, useState } from 'react';
import { useNavigate, BrowserRouter, NavLink, Route, Routes, useLocation, useParams } from 'react-router-dom';

export default function OneType() {
    // const location = useLocation();
    // console.log(location.pathname[location.pathname.length-1]);

    const param = useParams();
    const gotParam = Number(param.tipId);

    const apiUrl = `https://localhost:5001/api/Tipusok/${gotParam}`;

    const [type, setType] = useState([]);

    const navigate = useNavigate();

    useEffect(() => {
        (async () => {
            try {
                const type = await axios.get(apiUrl);
                setType(type.data);
            } catch (err) {
                console.log(err);
            }
        })();
    }, []);

    return (
        <div className='container'>
            <div className='row d-flex align-items-center justify-content-center'>
                    <div className='mt-5 p-3 col-10 col-md-8 col-xl-6'>
                            <div className='card h-100'>
                                {/* <img src={`${imgUrl}${type.imageURL}`} className='card-img-top' alt='...' /> */}
                                <div className='card-body'>
                                    <h5 className='card-title mb-5 text-center'>{type.megnevezes}</h5>
                                    <p>{type.leiras}</p>
                                    {/* <div>
                                        <button className='btn btn-outline-warning me-2'>
                                            <FontAwesomeIcon icon={faPencil} fixedWidth />
                                        </button>
                                        <button className='btn btn-outline-danger me-2'>
                                            <FontAwesomeIcon icon={faXmark} fixedWidth />
                                        </button>
                                        <button className='btn btn-outline-info'>
                                            <FontAwesomeIcon icon={faEye} fixedWidth />
                                        </button>
                                    </div> */}
                                </div>
                            </div>
                    </div>
            </div>
    </div>

  )
}
