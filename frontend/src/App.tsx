import React from 'react';
import './App.css';
import Header from './components/Header';
import Table from './components/Table';

function App() {
  return (
    <div className="App">
      <h1>Header:</h1>
      <Header />
      <h1>Table:</h1>
      <Table />
    </div>
  );
}

export default App;
