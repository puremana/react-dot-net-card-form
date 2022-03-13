import React, { useState } from 'react';
import './App.css';
import './AppMedia.css';
import Hamburger from './hamburger.png';
import Arrow from './arrow.png';
import Menu from './Menu';
const axios = require('axios').default;

var instance = axios.create({
  // baseURL: 'http://localhost:5292/api/',
  baseURL: 'https://localhost:7077/api/',
  timeout: 1000,
  headers: {'Access-Control-Allow-Origin': "*"}
});


function App() {
  const [showMenu, setShowMenu] = useState(false);
  const [cardNumber, setCardNumber] = useState("");
  const [cardCVC, setCardCVC] = useState("");
  const [cardExpiry, setCardExpiry] = useState("");
  const [user, setUser] = useState({
    "name": "Rune"
  });
  const [errorMessage, setErrorMessage] = useState("");

  function submit() {
    // Check none of the inputs are null
    if (cardNumber === "") {
      setErrorMessage("Invalid card number")
      return;
    }
    if (cardCVC === "") {
      setErrorMessage("Invalid CVC")
      return;
    }
    if (cardExpiry === "") {
      setErrorMessage("Invalid expiry")
      return;
    }

    let payload = {
      "name": "",
      "card": cardNumber,
      "cvc": cardCVC,
      "expiry": cardExpiry
    }

    instance.post('payments', payload)
      .then(function (response) {
        // handle success
        console.log(response);
      })
      .catch(function (error) {
        // handle error
        console.log(error);
      })
  }

  return (
    <div className="App">
      <header className="App-header">
        <div className="icon" onClick={() => setShowMenu(!showMenu)}>
          {!showMenu && <img src={Hamburger} alt="Hamburger Icon" />}
          {showMenu && <img src={Arrow} alt="Left Arrow Icon" />}
        </div>
        <h1>
          Register Card Form
        </h1>
      </header>
      {showMenu && <Menu />}
      <section>
        <div className="welcomeBox">
          {!errorMessage && <span>Welcome {user.name}</span>}
          {errorMessage && <span className="red">{errorMessage}</span>}
        </div>

        <div className="cardForm">
          <div className="cardForm-header">
            <h2>Card Details</h2>
          </div>
          <div>
            <label>
              Card Number
              <input type="number" pattern="[0-9]*" onChange={event => setCardNumber(event.target.value)} value={cardNumber} />
            </label>
          </div>
          <div>
            <label>
              CVC
              <input type="number" pattern="[0-9]*" onChange={event => setCardCVC(event.target.value)} value={cardCVC} />
            </label>
          </div>
          <div>
            <label>
              Expiry
              <input type="month" onChange={event => setCardExpiry(event.target.value)} value={cardExpiry} />
            </label>
          </div>
          <div className="button" onClick={submit}>
            Submit
          </div>
        </div>
      </section>
    </div>
  );
}

export default App;
