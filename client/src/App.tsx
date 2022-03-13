import React from 'react';
import './App.css';
import Hamburger from './hamburger.png';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img className="icon" src={Hamburger} />
        <h1>
          Register Card Form
        </h1>
      </header>
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
