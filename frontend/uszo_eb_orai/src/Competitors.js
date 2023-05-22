import React from 'react';
import axios from "axios";
import { useEffect, useState } from "react";
import { useNavigate, NavLink } from "react-router-dom";


export default function Competitors() {
    const [competitors, setCompetitors] = useState([]);
    const [isFetchPending, setFetchPending] = useState(false);

    const navigate = useNavigate();

    useEffect(() => {
        setFetchPending(true);
        (async () => {
            try {
                const competitors = await axios.get("https://localhost:5001/Versenyzok");
                setCompetitors(competitors.data);
            } catch (err) {
                console.log(err);
            } finally {
                setFetchPending(false);
            }
        })();
    }, []);

    return (
        <div className="p-5  m-auto text-center content bg-ivory">
            {isFetchPending ? (
                <div className="spinner-border"></div>
            ) : (
                <div>
                    <h2>Competitors:</h2>
                    <table className="table table-striped">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Name</th>
                                <th>CountryId</th>
                                <th>Sex</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            {competitors.map((competitor) => (
                                <tr key={competitor.id}>
                                    <td>{competitor.id}</td>
                                    <td>{competitor.nev}</td>
                                    <td>{competitor.orszagId}</td>
                                    <td>{competitor.nem}</td>
                                    <td>
                                    <NavLink to={"/competitor"}>
                                        <button onClick={() => {
                                        (async () => {
                                            try {
                                                const competitorA = await axios.delete(`https://localhost:5001/Versenyzok/${competitor.id}`);
                                                setCompetitors(competitorA.data);
                                                navigate('/');
                                            } catch (err) {
                                                console.log(err);
                                            } finally {
                                                setFetchPending(false);
                                            }
                                        })();
                                    }
                                    } className="btn btn-danger me-2">DEL</button>
                                    </NavLink>
                                    <NavLink to={`/competitor/${competitor.id}`}>
                                        <button className="btn btn-warning">EDIT</button>
                                    </NavLink>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                    <div>
                        <NavLink to={`/competitor/${0}`}>
                            <button className="btn btn-info mt-3">Add new competitor</button>
                        </NavLink>
                    </div>


                </div>
            )}
        </div>
    );
}

                //   <div className="card col-sm-3 d-inline-block m-1 p-2">
                //     <h6 className="text-muted">{competitor.brand}</h6>
                //     <h5 className="text-dark">{competitor.name}</h5>
                //     <div>{competitor.price} ft -</div>
                //     <div className="small">Készleten: {competitor.quantity} db</div>
                //     <div className="card-body">
                //       <img
                //         className="img-fluid"
                //         style={{ maxHeight: 200 }}
                //         src={competitor.imageURL ? competitor.imageURL : "https://via.placeholder.com/400x800"}
                //       />
                //     </div>
                //   </div>
