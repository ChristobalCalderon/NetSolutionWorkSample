import React from 'react';
import logo from './logo.svg';
import './App.css';
import Button from '@mui/material/Button';
import { Movie } from './models/Movie';
import useSWR from "swr";

const fetcher = (url:string) => fetch(url).then(_ => _.json());

function App() {
  const { data, error } = useSWR('http://localhost:12001/api/Movie/GetRatedMoviesAsync/1', fetcher);

  if (error) return <div>failed to load</div>
  if (!data) return <div>loading...</div>
  
  console.log(data)
  const movies:Movie[] = data.results;
  console.log(movies)

  return (
    <div className="App">
      <header className="App-header">
        <p>Data:</p>
        
        {movies && movies.map((movie:Movie, i:number) => {
          return <div><h2>{movie.id}</h2></div>;
        })}

        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;


