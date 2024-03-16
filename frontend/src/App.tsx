import React from 'react';
import './App.css';
import Header from './components/Header';
import Table from './components/Table';
import 'bootstrap/dist/css/bootstrap.min.css'; // Ensure Bootstrap CSS is imported

function App() {
  return (
    <div className="App">
      <Header />
      <Table />
    </div>
  );
}

export default App;
