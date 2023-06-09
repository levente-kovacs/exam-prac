import React from 'react';
import axios from 'axios';
import { useEffect, useState } from 'react';
import { useNavigate, BrowserRouter, NavLink, Route, Routes } from 'react-router-dom';

export default function Types() {
  
    const apiUrl = 'https://localhost:5001/api/Tipusok';

    const [types, setTypes] = useState([]);

    const navigate = useNavigate();

    useEffect(() => {
        // setFetchPending(true);
        (async () => {
            try {
                const types = await axios.get(apiUrl);
                console.log(types);
                setTypes(types.data);
            } catch (err) {
                console.log(err);
            } finally {
                // setFetchPending(false);
            }
        })();
    }, []);

    return (
        <div className='container'>
        {/* {isFetchPending ? (
            <div className="spinner-border"></div>
        ) : ( */}
            <div className='row'>
                <h1 className='text-center my-4'>Típusok:</h1>
                {types.map((type) => (
                    <div key={type.id} className='p-3 col-10 col-md-6 col-xl-4 mt-5'>
                        <NavLink to={{pathname: `/tip/${type.id}`, state: {typeId: type.id}}} className={({ isActive }) => "nav-link h-100" + (isActive ? " active" : "")} end>
                            <div className='card h-100'>
                                {/* <img src={`${imgUrl}${type.imageURL}`} className='card-img-top' alt='...' /> */}
                                <div className='card-body'>
                                    <h5 className='card-title mb-5 text-center'>{type.megnevezes}</h5>
                                    <p>{type.leiras}</p>
                                    <img src={`/images/${type.kepek}`} className="card-img-bottom" alt="..."></img>
                                </div>
                            </div>
                        </NavLink>
                        <div className='d-flex flew-row justify-content-center w-100'>
                            <div className='mt-2'>
                                <NavLink to={`/edit-tip/${type.id}`}>
                                    <button className='btn btn-warning me-2'>
                                        EDIT
                                    </button>
                                </NavLink>
                                <NavLink to={"/"}>
                                    <button onClick={() => {
                                        (async () => {
                                            try {
                                                const typeA = await axios.delete(`${apiUrl}/${type.id}`);
                                                setTypes(typeA.data);
                                                navigate('/');
                                            } catch (err) {
                                                console.log(err);
                                            }
                                        })();
                                    }
                                    } className="btn btn-danger">DEL</button>
                                </NavLink>
                                {/* <button className='btn btn-outline-info'>
                                    <FontAwesomeIcon icon={faEye} fixedWidth />
                                </button> */}
                            </div>
                        </div>
                    </div>
                ))}
            </div>
        {/* )} */}
    </div>

  )
}
