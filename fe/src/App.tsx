import { useState } from 'react'
import './App.css'

function App() {
  const [formData, setFormData] = useState(0)

  return (
    <>
      <h2>CarJournal</h2>
      <form className='input-form'>
        <input className='distance-counter' type='number' placeholder='Mätarställning i km'></input>
        <input className='cost-counter' type='number' placeholder='kostnad i kronor'></input>
        <button className='send-button'>SPARA</button>
      </form>
    </>
  )

  
}

export default App
