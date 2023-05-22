import { BrowserRouter, NavLink, Route, Routes } from 'react-router-dom';
import './App.css';
import Recipe from './Recipe';
import Home from './Home';
import NewRecipe from './NewRecipe';

function App() {
  return (
    <BrowserRouter>
      <nav className="navbar navbar-expand-sm navbar-dark bg-primary fw-bold">
        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav">
            <li className="nav-item">
              <NavLink to={`/`} className={({ isActive }) => "nav-link" + (isActive ? " active" : "")} end>
                <img className='logo' src="http://localhost:9090/static/assets/logo.png" alt="Logo" />
              </NavLink>
            </li>
            <li className="nav-item">
              <NavLink to={`/recipe`} className={({ isActive }) => "nav-link" + (isActive ? " active" : "")} end>
                <span className="nav-link">Receptek</span>
              </NavLink>
            </li>
            <li className="nav-item">
              <NavLink to={`/new-recipe`} className={({ isActive }) => "nav-link" + (isActive ? " active" : "")} end>
                <span className="nav-link">Új recept</span>
              </NavLink>
            </li>
          </ul>
        </div>
      </nav>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/recipe" element={<Recipe />} />
        <Route path="/new-recipe" element={<NewRecipe />} />
        {/* <Route path="/competitor/:competitorId" element={<NewCompetitor />} /> */}

      </Routes>
    </BrowserRouter>
  );
}

export default App;
