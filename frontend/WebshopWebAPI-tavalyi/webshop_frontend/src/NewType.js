import React from 'react';
import axios from "axios";
import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

export default function NewType() {
    const [competitor, setCompetitor] = useState();
    const [isFetchPending, setFetchPending] = useState(true);

    const navigate = useNavigate();
    // const param = useParams();
    // const gotParam = Number(param.tipId);

    const apiUrl = `https://localhost:5001/api/UjTipusok`;

    // useEffect(() => {
    //     console.log('paramelotte', gotParam);
    //     if (gotParam !== 0) {
    //         (async () => {
    //             try {
    //                 const competitorAxios = await axios.get(`https://localhost:5001/Versenyzok/${param.competitorId}`);
    //                 setCompetitor(competitorAxios.data[0]);
    //             } catch (err) {
    //                 console.log(err);
    //             } finally {
    //                 setFetchPending(false);
    //             }
    //         })();
    //     } else {
    //         setFetchPending(false);
    //     }
    // }, []);  
  
    return (
    <div className='container d-flex align-items-center justify-content-center'>
        <div className='card mt-5 my-3 p-4 col-10 col-md-8 col-xl-6'>
            <h1 className='text-center mb-4'>New Type:</h1>
            <form action=''
                onSubmit={(e) => {
                    e.preventDefault();
                    // if (gotParam === 0) {
                        (async () => {
                            try {
                                await axios.post(apiUrl, {
                                    kepek: e.target.elements.picture.value,
                                    megnevezes: e.target.elements.name.value,
                                    leiras: e.target.elements.description.value,
                                });
                                navigate("/");
                            } catch (err) {
                                console.log(err);
                            }
                        })();
                    // }
                }}            
            >
                <div className="form-group mt-3">
                    <label className='mb-1'>Megnevezés</label>
                    <input type="text" className="form-control" id="name" name='name' placeholder="Megnevezés" />
                </div>
                <div className="form-group mt-3">
                    <label className='mb-1'>Leírás</label>
                    <input type="text" className="form-control" id="description" name='description' placeholder="Leírás" />
                </div>
                <div className="form-group mt-3">
                    <label className='mb-1'>Kép</label>
                    <input type="text" className="form-control" id="picture" name='picture' placeholder="Kép" />
                </div>

                <button type='submit' className='btn mt-5 col-12' style={{ backgroundColor: 'limegreen', color: 'white' }}>
                    Küldés
                </button>

            </form>
        </div>
    </div>
  )
}
