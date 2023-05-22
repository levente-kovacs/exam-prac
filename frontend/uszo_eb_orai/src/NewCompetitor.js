import React from 'react';
import axios from "axios";
import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

export default function NewCompetitor() {
    const [competitor, setCompetitor] = useState();
    const [isFetchPending, setFetchPending] = useState(true);

    const navigate = useNavigate();
    const param = useParams();
    const gotParam = Number(param.competitorId);

    useEffect(() => {
        console.log('paramelotte', gotParam);
        if (gotParam !== 0) {
            (async () => {
                try {
                    const competitorAxios = await axios.get(`https://localhost:5001/Versenyzok/${param.competitorId}`);
                    setCompetitor(competitorAxios.data[0]);
                } catch (err) {
                    console.log(err);
                } finally {
                    setFetchPending(false);
                }
            })();
        } else {
            setFetchPending(false);
        }
    }, []);

    if (isFetchPending) {
        return <div className="spinner-border"></div>
    } else {
        return (
            <div className="p-5 content bg-whitesmoke text-center">
                {gotParam === 0 &&
                    <h2>Add new competitor</h2>
                }
                {gotParam > 0 &&
                    <h2 className="mb-5">Edit {competitor.nev} competitor</h2>
                }
                <form
                    onSubmit={(e) => {
                        e.preventDefault();
                        if (gotParam === 0) {
                            (async () => {
                                try {
                                    await axios.post("https://localhost:5001/Versenyzok/", {
                                        Nev: e.target.elements.name.value,
                                        OrszagId: e.target.elements.countryId.value,
                                        Nem: e.target.elements.sex.value,
                                    });
                                    navigate("/");
                                } catch (err) {
                                    console.log(err);
                                }
                            })();
                        } else {
                            (async () => {
                                try {
                                    await axios.put(`https://localhost:5001/Versenyzok/`, {
                                        Id: param.competitorId,
                                        Nev: e.target.elements.name.value,
                                        OrszagId: Number(e.target.elements.countryId.value),
                                        Nem: e.target.elements.sex.value,
                                    });
                                    navigate("/");
                                } catch (err) {
                                    console.log(err);
                                }
                            })();
                        }

                    }}
                >
                    <div className="form-group row pb-3">
                        <label className="col-sm-3 col-form-label">Name:</label>
                        <div className="col-sm-9">
                            {gotParam === 0 &&
                                <input type="text" name="name" className="form-control" />
                            }
                            {gotParam > 0 &&
                                <input defaultValue={competitor.nev} type="text" name="name" className="form-control" />
                            }
                        </div>
                    </div>
                    <div className="form-group row pb-3">
                        <label className="col-sm-3 col-form-label">CountryId:</label>
                        <div className="col-sm-9">
                            {gotParam === 0 &&
                                <input type="number" name="countryId" className="form-control" />
                            }
                            {gotParam > 0 &&
                                <input defaultValue={competitor.orszagId} type="number" name="countryId" className="form-control" />
                            }
                        </div>
                    </div>
                    <div className="form-group row pb-3">
                        <label className="col-sm-3 col-form-label">Sex:</label>
                        <div className="col-sm-9">
                            {gotParam === 0 &&
                                <select name="sex" id="sex">
                                    <option value="N">Female</option>
                                    <option value="F">Male</option>
                                </select>
                            }
                            {gotParam > 0 &&
                                <select defaultValue={competitor.nem} name="sex" id="sex">
                                    <option value="N">Female</option>
                                    <option value="F">Male</option>
                                </select>
                            }
                        </div>
                    </div>
                    <button type="submit" className="btn btn-success">
                        Submit
                    </button>
                </form>
            </div>
        );

    }
}