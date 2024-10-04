import { Form, Row, Col, Table, Button } from 'react-bootstrap';
import { Link, useNavigate, useParams } from 'react-router-dom';
import { useEffect, useRef, useState } from 'react';
import { FaTrash } from 'react-icons/fa';
import Service from '../../services/GrupaService';
import SmjerService from '../../services/SmjerService';
import PolaznikService from '../../services/PolaznikService';
import { RoutesNames } from '../../constants';
import { AsyncTypeahead } from 'react-bootstrap-typeahead';

import useLoading from "../../hooks/useLoading";


export default function GrupePromjena() {
  const navigate = useNavigate();
  const routeParams = useParams();
  const { showLoading, hideLoading } = useLoading();

  const [smjerovi, setSmjerovi] = useState([]);
  const [smjerSifra, setSmjerSifra] = useState(0);
  const [polaznici, setPolaznici] = useState([]);
  const [pronadeniPolaznici, setPronadeniPolaznici] = useState([]);

  const [grupa, setGrupa] = useState({});

  const typeaheadRef = useRef(null);

  async function dohvatiSmjerove(){
    const odgovor = await SmjerService.get();
    setSmjerovi(odgovor);
  }

  async function dohvatiGrupa() {
    const odgovor = await Service.getBySifra(routeParams.sifra);
    if(odgovor.greska){
      alert(odgovor.poruka);
      return;
  }
    let grupa = odgovor.poruka;
    setGrupa(grupa);
    setSmjerSifra(grupa.smjerSifra); 
  }

  async function dohvatiPolaznici() {
    const odgovor = await Service.getPolaznici(routeParams.sifra);
    if(odgovor.greska){
      alert(odgovor.poruka);
      return;
    }
    setPolaznici(odgovor.poruka);
  }

  async function traziPolaznik(uvjet) {
    const odgovor =  await PolaznikService.traziPolaznik(uvjet);
    if(odgovor.greska){
      alert(odgovor.poruka);
      return;
    }
    setPronadeniPolaznici(odgovor.poruka);
  }

  async function dodajPolaznika(e) {
    showLoading();
    const odgovor = await Service.dodajPolaznika(routeParams.sifra, e[0].sifra);
    if(odgovor.greska){
      alert(odgovor.podaci);
      return;
    }
      await dohvatiPolaznici();
      typeaheadRef.current.clear();
      hideLoading();
  }

  async function obrisiPolaznika(polaznik) {
    showLoading();
    const odgovor = await Service.obrisiPolaznika(routeParams.sifra, polaznik);
    hideLoading();
    if(odgovor.greska){
      alert(odgovor.podaci);
      return;
    }
      await dohvatiPolaznici();
  }


  async function dohvatiInicijalnePodatke() {
    showLoading();
    await dohvatiSmjerove();
    await dohvatiGrupa();
    await dohvatiPolaznici();
    hideLoading();
  }


  useEffect(()=>{
    dohvatiInicijalnePodatke();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  },[]);

  async function promjena(e){
    const odgovor = await Service.promjena(routeParams.sifra,e);
    if(odgovor.greska){
        alert(odgovor.poruka);
        return;
    }
    navigate(RoutesNames.GRUPA_PREGLED);
}

  function obradiSubmit(e) {
    e.preventDefault();

    const podaci = new FormData(e.target);


    promjena({
      naziv: podaci.get('naziv'),
      smjerSifra: parseInt(smjerSifra),
      predavac: podaci.get('predavac'),
      maksimalnopolaznika: parseInt(podaci.get('maksimalnopolaznika'))
    });
  }

  return (
      <>
      Mjenjanje podataka grupe
      <Row>
        <Col key='1' sm={12} lg={6} md={6}>
          <Form onSubmit={obradiSubmit}>
              <Form.Group controlId="naziv">
                  <Form.Label>Naziv</Form.Label>
                  <Form.Control type="text" name="naziv" required defaultValue={grupa.naziv}/>
              </Form.Group>

              <Form.Group className='mb-3' controlId='smjer'>
                <Form.Label>Smjer</Form.Label>
                <Form.Select
                value={smjerSifra}
                onChange={(e)=>{setSmjerSifra(e.target.value)}}
                >
                {smjerovi && smjerovi.map((s,index)=>(
                  <option key={index} value={s.sifra}>
                    {s.naziv}
                  </option>
                ))}
                </Form.Select>
              </Form.Group>

              <Form.Group controlId="predavac">
                  <Form.Label>Predavač</Form.Label>
                  <Form.Control type="text" name="predavac" required defaultValue={grupa.predavac}/>
              </Form.Group>

              <Form.Group controlId="maksimalnopolaznika">
                  <Form.Label>Maksimalno polaznika</Form.Label>
                  <Form.Control type="number" name="maksimalnopolaznika" min={5} max={30} defaultValue={grupa.maksimalnoPolaznika}/>
              </Form.Group>


              <hr />
              <Row>
                  <Col xs={6} sm={6} md={3} lg={6} xl={6} xxl={6}>
                  <Link to={RoutesNames.GRUPA_PREGLED}
                  className="btn btn-danger siroko">
                  Odustani
                  </Link>
                  </Col>
                  <Col xs={6} sm={6} md={9} lg={6} xl={6} xxl={6}>
                  <Button variant="primary" type="submit" className="siroko">
                      Promjeni grupu
                  </Button>
                  </Col>
              </Row>
          </Form>
        </Col>
        <Col key='2' sm={12} lg={6} md={6}>
        <div style={{overflow: 'auto', maxHeight:'400px'}}>
        <Form.Group className='mb-3' controlId='uvjet'>
          <Form.Label>Traži polaznika</Form.Label>
            <AsyncTypeahead
            className='autocomplete'
            id='uvjet'
            emptyLabel='Nema rezultata'
            searchText='Tražim...'
            labelKey={(polaznik) => `${polaznik.prezime} ${polaznik.ime}`}
            minLength={3}
            options={pronadeniPolaznici}
            onSearch={traziPolaznik}
            placeholder='dio imena ili prezimena'
            renderMenuItemChildren={(polaznik) => (
              <>
                <span>
                   {polaznik.prezime} {polaznik.ime}
                </span>
              </>
            )}
            onChange={dodajPolaznika}
            ref={typeaheadRef}
            />
          </Form.Group>
          <Table striped bordered hover>
            <thead>
              <tr>
                <th>Polaznici na grupi</th>
                <th>Akcija</th>
              </tr>
            </thead>
            <tbody>
              {polaznici &&
                polaznici.map((polaznik, index) => (
                  <tr key={index}>
                    <td>
                       {polaznik.ime} {polaznik.prezime}
                      
                    </td>
                    <td>
                      <Button variant='danger' onClick={() =>
                          obrisiPolaznika(polaznik.sifra)
                        } >
                        <FaTrash />
                      </Button>
      
                    </td>
                  </tr>
                ))}
            </tbody>
          </Table>
          </div>
        </Col>
        </Row>
        </>
  );
}
