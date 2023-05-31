import React from 'react';
import axios from 'axios';
import { useEffect, useState } from 'react';
import { useNavigate, BrowserRouter, NavLink, Route, Routes, useLocation, useParams } from 'react-router-dom';

export default function EditType() {
  
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
        <div className="p-5 content bg-whitesmoke text-center">
        <h2>Új típus</h2>
        <form action=''
          onSubmit={(e) => {
            e.preventDefault();
            // if (gotParam === 0) {
                (async () => {
                    try {
                        await axios.put(apiUrl, {
                            kepek: e.target.elements.Kepek.value,
                            megnevezes: e.target.elements.Megnevezes.value,
                            leiras: e.target.elements.Leiras.value,
                        });
                        navigate("/");
                    } catch (err) {
                        console.log(err);
                    }
                })();
            // }
        }}>
          <div className="form-group row pb-3">
            <label className="col-sm-3 col-form-label">Megnevezés:</label>
            <div className="col-sm-9">
              <input defaultValue={type.megnevezes} type="text" name="Megnevezes" className="form-control" />
            </div>
          </div>
          <div className="form-group row pb-3">
            <label className="col-sm-3 col-form-label">Leírás:</label>
            <div className="col-sm-9">
              <input defaultValue={type.leiras} type="text" name="Leiras" className="form-control" />
            </div>
          </div>
          <div className="form-group row pb-3">
            <label className="col-sm-3 col-form-label">Kép neve:</label>
            <div className="col-sm-9">
              <input defaultValue={type.kepek} type="text" name="Kepek" className="form-control" />
            </div>
          </div>
          <button type="submit" className="btn btn-success">
            Küldés
          </button>
  
        </form>
      </div>
    )
}
