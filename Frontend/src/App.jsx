import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css'
import NavBarEdunova from './components/NavBarEdunova'
import { Route, Routes } from 'react-router-dom'
import { RoutesNames } from './constants'
import Pocetna from './pages/Pocetna'
import SmjeroviPregled from './pages/smjerovi/SmjeroviPregled'
import SmjeroviDodaj from './pages/smjerovi/SmjeroviDodaj'
import SmjeroviPromjena from './pages/smjerovi/SmjeroviPromjena'
import { Container } from 'react-bootstrap'
import PolazniciPregled from './pages/polaznici/PolazniciPregled'
import PolazniciDodaj from './pages/polaznici/PolazniciDodaj'
import PolazniciPromjena from './pages/polaznici/PolazniciPromjena'
import GrupePregled from './pages/grupe/GrupePregled'
import GrupeDodaj from './pages/grupe/GrupeDodaj'
import GrupePromjena from './pages/grupe/GrupePromjena'

import LoadingSpinner from './components/LoadingSpinner'


function App() {

  function godina(){
    const pocenta = 2024;
    const trenutna = new Date().getFullYear();
    if(pocenta===trenutna){
      return trenutna;
    }
    return pocenta + ' - ' + trenutna;
  }
  
  return (
    <>
      <LoadingSpinner />
      <Container className='aplikacija'>
        <NavBarEdunova />
        <Routes>
          <Route path={RoutesNames.HOME} element={<Pocetna />} />

          <Route path={RoutesNames.SMJER_PREGLED} element={<SmjeroviPregled />} />
          <Route path={RoutesNames.SMJER_NOVI} element={<SmjeroviDodaj />} />
          <Route path={RoutesNames.SMJER_PROMJENA} element={<SmjeroviPromjena />} />

          <Route path={RoutesNames.POLAZNIK_PREGLED} element={<PolazniciPregled />} />
          <Route path={RoutesNames.POLAZNIK_NOVI} element={<PolazniciDodaj />} />
          <Route path={RoutesNames.POLAZNIK_PROMJENA} element={<PolazniciPromjena />} />

          <Route path={RoutesNames.GRUPA_PREGLED} element={<GrupePregled />} />
          <Route path={RoutesNames.GRUPA_NOVI} element={<GrupeDodaj />} />
          <Route path={RoutesNames.GRUPA_PROMJENA} element={<GrupePromjena />} />
        </Routes>
      </Container>
      <Container>
        <hr />
        Edunova &copy; {godina()}
      </Container>
    </>
  )
}

export default App
