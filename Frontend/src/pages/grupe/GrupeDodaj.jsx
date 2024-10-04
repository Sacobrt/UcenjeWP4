import { Button, Col, Container, Form, Row} from 'react-bootstrap';
import { Link, useNavigate } from 'react-router-dom';
import { useEffect, useState } from 'react';
import Service from '../../services/GrupaService';
import SmjerService from '../../services/SmjerService';
import { RoutesNames } from '../../constants';

import useLoading from "../../hooks/useLoading";


export default function GrupeDodaj() {
  const navigate = useNavigate();
  const { showLoading, hideLoading } = useLoading();

  const [smjerovi, setSmjerovi] = useState([]);
  const [smjerSifra, setSmjerSifra] = useState(0);

  async function dohvatiSmjerove(){
    showLoading();
    const odgovor = await SmjerService.get();
    setSmjerovi(odgovor);
    setSmjerSifra(odgovor[0].sifra);
    hideLoading();
  }



  useEffect(()=>{
    dohvatiSmjerove();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  },[]);

  async function dodaj(e) {
    showLoading();
    const odgovor = await Service.dodaj(e);
    hideLoading();
    if(odgovor.greska){
      alert(odgovor.poruka);
      return;
    }
    navigate(RoutesNames.GRUPA_PREGLED);
  }

  function obradiSubmit(e) {
    e.preventDefault();

    const podaci = new FormData(e.target);


    dodaj({
      naziv: podaci.get('naziv'),
      smjerSifra: parseInt(smjerSifra),
      predavac: podaci.get('predavac'),
      maksimalnopolaznika: parseInt(podaci.get('maksimalnopolaznika'))
    });
  }

  return (
      <>
      Dodavanje nove grupe
      
      <Form onSubmit={obradiSubmit}>
          <Form.Group controlId="naziv">
              <Form.Label>Naziv</Form.Label>
              <Form.Control type="text" name="naziv" required />
          </Form.Group>

          <Form.Group className='mb-3' controlId='smjer'>
            <Form.Label>Smjer</Form.Label>
            <Form.Select 
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
              <Form.Control type="text" name="predavac" required />
          </Form.Group>


          <Form.Group controlId="maksimalnopolaznika">
              <Form.Label>Maksimalno polaznika</Form.Label>
              <Form.Control type="number" name="maksimalnopolaznika" min={5} max={30} />
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
                  Dodaj novu grupu
              </Button>
              </Col>
          </Row>
      </Form>
  </>
  );
}
