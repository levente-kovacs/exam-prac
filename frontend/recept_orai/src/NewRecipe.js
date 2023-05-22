import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faPlus, faTrash } from '@fortawesome/free-solid-svg-icons';

export default function NewRecipe() {

    let ingredientsCounter = 0;
    let stepsCounter = 0;

    function addIngredientsInputs() {
        // e.preventDefault();
        console.log('asdasd');
        const parentElement = document.querySelector('.ingredients');
        // const trashIcon = <FontAwesomeIcon icon={faTrash} fixedWidth />;
        // console.log(trashIcon);
        const template = `<div class='ingredient-${ingredientsCounter} d-flex flex-column flex-md-row'>
                <div class='col-2'></div>
                <div class='w-100 me-md-3 mt-2'>
                    <input type='text' class='form-control' name='' placeholder='Név' />
                </div>
                <div class='col-md-2 me-md-3 mt-2'>
                    <input type='number' class='form-control' name='' placeholder='Mennyiség' />
                </div>
                <div class='col-md-2 me-md-3 mt-2'>
                    <input type='text' class='form-control' name='' placeholder='Típus' />
                </div>
                <div class='col-md-2 mt-2'>
                    <button onClick={delIngredientsInputs} class='ingredient-del-${ingredientsCounter} btn btn-danger'>
                        -
                    </button>
                </div>
            </div>`;
        parentElement.insertAdjacentHTML('beforeend', template);
        ingredientsCounter++;
    }


    function addStepsInputs() {
        // e.preventDefault();
        const parentElement = document.querySelector('.steps');
        // const trashIcon = <FontAwesomeIcon icon={faTrash} fixedWidth />;
        // console.log(trashIcon);
        const template = `<div class='d-flex flex-column flex-md-row'>
                <div class='col-2'></div>
                <div class='w-100 me-md-3 mt-2'>
                    <input type='text' class='form-control' name='' placeholder='1. lépés' />
                </div>
                <div class='col-md-2 me-md-3 mt-2'>
                    <input type='number' class='form-control' name='' placeholder='Idő' />
                </div>
                <div class='col-md-2 mt-2'>
                    <button class='btn btn-danger'>
                        -
                    </button>
                </div>
            </div>`;
        parentElement.insertAdjacentHTML('beforeend', template);
        stepsCounter++;
    }

    function delIngredientsInputs() {
        
    }

    return (
        <div className='container'>
            <div className='card my-3'>
                <form action=''>
                    <ul className='list-group list-group-flush'>
                        <li className='list-group-item py-3'>
                            <h1>Új recept:</h1>
                            <hr />
                            <div className='d-flex flex-row'>
                                <div className='col-2'>
                                    <label className='col-form-label fw-bold'>Név:</label>
                                </div>
                                <div className='w-100'>
                                    <input type='password' id='inputPassword6' className='form-control' aria-describedby='passwordHelpInline' />
                                </div>
                                {/* <div className='col-auto'>
                                    <span id='passwordHelpInline' className='form-text'>
                                        Must be 8-20 characters long.
                                    </span>
                                </div> */}
                            </div>
                        </li>

                        <li className='list-group-item py-3'>
                            <label className='col-form-label fw-bold'>Hozzávalók:</label>
                            <div className='ingredients d-flex flex-column'>

                            </div>
                            <div className='d-flex justify-content-end mt-3'>
                                <button onClick={addIngredientsInputs} className='btn' type='button' style={{ backgroundColor: 'limegreen', color: 'white' }}>
                                    <FontAwesomeIcon icon={faPlus} fixedWidth />
                                </button>
                            </div>
                        </li>

                        <li className='list-group-item py-3'>
                            <label className='col-form-label fw-bold'>Lépések:</label>
                            <div className='steps d-flex flex-column'>

                            </div>
                            <div className='d-flex justify-content-end mt-3'>
                                <button onClick={addStepsInputs} className='btn' type='button' style={{ backgroundColor: 'limegreen', color: 'white' }}>
                                    <FontAwesomeIcon icon={faPlus} fixedWidth />
                                </button>
                            </div>
                        </li>

                        <li className='list-group-item py-3'>
                            <label className='col-form-label fw-bold'>Kép:</label>
                            <div className='d-flex flex-column flex-md-row mb-3'>
                                <div className='col-2'></div>
                                <div className='w-100 d-flex justify-content-center'>
                                    <div className='col-6'>
                                        {/* <label for='formFile' className='form-label'>Default file input example</label> */}
                                        <input className='form-control' type='file' id='formFile' />
                                    </div>

                                </div>
                            </div>
                        </li>

                        <li className='list-group-item py-3'>
                            <button className='btn' style={{ backgroundColor: 'limegreen', color: 'white' }}>
                                Küldés<FontAwesomeIcon icon={faPlus} fixedWidth />
                            </button>
                        </li>


                    </ul>
                </form>
            </div>
        </div>
    )
}
