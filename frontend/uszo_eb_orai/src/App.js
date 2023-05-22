import { BrowserRouter, NavLink, Route, Routes } from 'react-router-dom';
import './App.css';
import Competitors from './Competitors';
import NewCompetitor from './NewCompetitor';

function App() {
  return (

    <BrowserRouter>
      <nav className="navbar navbar-expand-sm navbar-dark bg-dark">
        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav">
            <li className="nav-item">
              <NavLink to={`/`} className={({ isActive }) => "nav-link" + (isActive ? " active" : "")} end>
                <span className="nav-link">Versenyzok</span>
              </NavLink>
            </li>
            {/* <li className="nav-item">
          <NavLink to={`/uj-hangszer`} className={({ isActive }) => "nav-link" + (isActive ? " active" : "")}>
            <span className="nav-link">Új hangszer</span>
          </NavLink>
        </li> */}
          </ul>
        </div>
      </nav>
      <Routes>
        <Route path="/" element={<Competitors />} />
        <Route path="/competitor/:competitorId" element={<NewCompetitor />} />

      </Routes>
    </BrowserRouter>
  )
}

export default App;
