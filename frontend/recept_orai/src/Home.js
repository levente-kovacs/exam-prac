import React from 'react';
import { NavLink } from "react-router-dom";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCircleArrowRight } from '@fortawesome/free-solid-svg-icons';


export default function Home() {

    return (
        <div className='container'>
            <div className='card border-0 mt-3' style={{backgroundColor: '#e4e4e4'}}>
                <div className='card-body my-5 mx-3'>
                    <h1 className='card-title'>Üdv a recept appban!</h1>
                    <p className='card-text fw-bold'>Jelenleg- 9 recept elérhető.</p>
                    <NavLink to={'/recipe'}>
                        <button className="btn btn-primary">
                            Tovább <FontAwesomeIcon icon={faCircleArrowRight} fixedWidth />
                        </button>
                    </NavLink>

                    {/* <a href='#' className='btn btn-primary'>Tovább</a> */}
                </div>
            </div>
        </div>
    )


}

// http://localhost:9090/static/images/picVfzLZo.jpg
// http://localhost:9090/static/images/picVfzLZo.jpg
