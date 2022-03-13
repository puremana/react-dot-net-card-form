import React, { useState } from 'react';
import './App.css';
import './AppMedia.css';
import Hamburger from './hamburger.png';
import Arrow from './arrow.png';
import Menu from './Menu';



function App() {
  const [showMenu, setShowMenu] = useState(false);

  return (
    <div className="App">
      <header className="App-header">
        <div className="icon" onClick={() => setShowMenu(!showMenu)}>
          {!showMenu && <img src={Hamburger} />}
          {showMenu && <img src={Arrow} />}
        </div>
        <h1>
          Register Card Form
        </h1>
      </header>
      {showMenu && <Menu />}
      <section>
        <div className="cardForm">
          <div className="cardForm-header">
            <h2>Card Details</h2>
          </div>
          <div>
            <label>
              Card Number
              <input type="text" />
            </label>
          </div>
          <div>
            <label>
              CVC
              <input type="text" />
            </label>
          </div>
          <div>
            <label>
              Expiry
              <input type="month" />
            </label>
          </div>
          <div className="button">
            Submit
          </div>
        </div>
      </section>
    </div>
  );
}

export default App;
