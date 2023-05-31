import './App.css';
import { BrowserRouter, NavLink, Route, Routes } from 'react-router-dom';
import Types from './Types';
import TipCreatePage from './TipCreatePage';
import OneType from './OneType';
import EditType from './EditType';

function App() {
  console.log('asd');
  return (
    <BrowserRouter>
      <nav className="navbar navbar-expand-sm navbar-dark bg-dark fw-bold">
        <div className="container-fluid">
          <NavLink to={`/`} className={({ isActive }) => "nav-link" + (isActive ? " active" : "")} end>
            <span className="navbar-brand">Types</span>
          </NavLink>

          {/* <a className="navbar-brand" href="#">Navbar</a> */}
          <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarNav">
            <ul className="navbar-nav">
              {/* <li className="nav-item">
                <NavLink to={`/`} className={({ isActive }) => "nav-link" + (isActive ? " active" : "")} end>
                  <img className='logo' src="http://localhost:9090/static/assets/logo.png" alt="Logo" />
                </NavLink>
              </li> */}
              {/* <li className="nav-item">
              </li> */}
              <li className="nav-item">
                <NavLink to={`/uj-tip`} className={({ isActive }) => "nav-link" + (isActive ? " active" : "")} end>
                  <span className="nav-link">New Type</span>
                </NavLink>
              </li>
            </ul>
          </div>
        </div>
      </nav>
    <Routes>
      <Route path="/" element={<Types />} />
      <Route path="/tip/:tipId" element={<OneType />} />
      <Route path="/uj-tip" element={<TipCreatePage />} />
      <Route path="/edit-tip/:tipId" element={<EditType />} />
      {/* <Route path="/recipe" element={<Recipe />} />
      <Route path="/new-recipe" element={<NewRecipe />} /> */}
      {/* <Route path="/competitor/:competitorId" element={<NewCompetitor />} /> */}
    </Routes>
  </BrowserRouter>
  )

//   return (
//     <nav className="navbar navbar-expand-sm navbar-dark bg-dark">
//       <div className="collapse navbar-collapse" id="navbarNav">
//         <ul className="navbar-nav">
//           <li className="nav-item">
//            <span className="nav-link">Garbage</span>
           
//           </li>
//           <li className="nav-item">
//             <span className="nav-link">New garbage</span>
//           </li>
//         </ul>
//       </div>
//     </nav>
// );
}

export default App;
