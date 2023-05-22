import React from 'react';
import axios from 'axios';
import { useEffect, useState } from 'react';
import { useNavigate, NavLink } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faPencil, faXmark, faEye } from '@fortawesome/free-solid-svg-icons';


export default function Recipe() {
    const apiUrl = 'http://localhost:9090/api/recipes/';
    const imgUrl = 'http://localhost:9090/static/images/';

    const [recipes, setRecipes] = useState([]);
    const [isFetchPending, setFetchPending] = useState(false);

    const navigate = useNavigate();

    useEffect(() => {
        setFetchPending(true);
        (async () => {
            try {
                const recipes = await axios.get(apiUrl);
                setRecipes(recipes.data);
            } catch (err) {
                console.log(err);
            } finally {
                setFetchPending(false);
            }
        })();
    }, []);

    console.log(recipes);

    return (
        <div className='container'>
            {isFetchPending ? (
                <div className="spinner-border"></div>
            ) : (
                <div className='row'>
                    {recipes.map((recipe) => (
                        <div key={recipe.id} className='p-3 col-10 col-md-6 col-xl-4'>
                            <div className='card'>
                                <img src={`${imgUrl}${recipe.imageURL}`} className='card-img-top' alt='...' />
                                <div className='card-body'>
                                    <h5 className='card-title mb-5'>{recipe.name}</h5>
                                    <div>
                                        <button className='btn btn-outline-warning me-2'>
                                            <FontAwesomeIcon icon={faPencil} fixedWidth />
                                        </button>
                                        <button className='btn btn-outline-danger me-2'>
                                            <FontAwesomeIcon icon={faXmark} fixedWidth />
                                        </button>
                                        <button className='btn btn-outline-info'>
                                            <FontAwesomeIcon icon={faEye} fixedWidth />
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    ))}
                </div>
            )}
        </div>
    )

}
