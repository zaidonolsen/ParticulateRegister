import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { ParticulateProvider } from './context/ParticulateContext';
import ParticulateList from './components/ParticulateList';
import ParticulateDetail from './components/ParticulateDetail';
import ParticulateForm from './components/ParticulateForm';
import './App.css';

function App() {
    return (
        <ParticulateProvider>
            <Router>
                <Routes>
                    <Route path="/" element={<ParticulateList />} />
                    <Route path="/detail/:id" element={<ParticulateDetail />} />
                    <Route path="/edit/:id" element={<ParticulateForm />} />
                    <Route path="/register" element={<ParticulateForm />} />
                </Routes>
            </Router>
        </ParticulateProvider>
    );
}

export default App;