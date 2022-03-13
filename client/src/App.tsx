import React from 'react';
import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">

      </header>
      <section>
        <div className="cardForm">
          <div className="cardForm-header">
            <h1>Register Card</h1>
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
