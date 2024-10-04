import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import { RoutesNames } from "../../constants";
import PolaznikService from "../../services/PolaznikService";
import { useEffect, useState } from "react";

import useLoading from "../../hooks/useLoading";



export default function PolazniciPromjena(){

    const navigate = useNavigate();
    const routeParams = useParams();
    const [polaznik,setPolaznik] = useState({});

    const { showLoading, hideLoading } = useLoading();


    async function dohvatiPolaznik(){
        showLoading();
        const odgovor = await PolaznikService.getBySifra(routeParams.sifra);
        hideLoading();
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        setPolaznik(odgovor.poruka);
    }

    useEffect(()=>{
        dohvatiPolaznik();
    },[]);

    async function promjena(e){
        showLoading();
        const odgovor = await PolaznikService.promjena(routeParams.sifra,e);
        hideLoading();
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        navigate(RoutesNames.POLAZNIK_PREGLED);
    }

    function obradiSubmit(e){ // e predstavlja event
        e.preventDefault();

        const podaci = new FormData(e.target);

        promjena({
            ime: podaci.get('ime'),
            prezime: podaci.get('prezime'),
            email: podaci.get('email'),
            oib: podaci.get('oib')
        });

    }

    return(
        <>
            Promjena Polaznika
            
            <Form onSubmit={obradiSubmit}>
            <Form.Group controlId="ime">
                    <Form.Label>Ime</Form.Label>
                    <Form.Control type="text" name="ime" required defaultValue={polaznik.ime}/>
                </Form.Group>

                <Form.Group controlId="prezime">
                    <Form.Label>Prezime</Form.Label>
                    <Form.Control type="text" name="prezime" required  defaultValue={polaznik.prezime}/>
                </Form.Group>

                <Form.Group controlId="email">
                    <Form.Label>Email</Form.Label>
                    <Form.Control type="text" name="email" required  defaultValue={polaznik.email}/>
                </Form.Group>

                <Form.Group controlId="oib">
                    <Form.Label>oib</Form.Label>
                    <Form.Control type="text" name="oib"  defaultValue={polaznik.oib}/>
                </Form.Group>



                <hr />
                <Row>
                    <Col xs={6} sm={6} md={3} lg={6} xl={6} xxl={6}>
                    <Link to={RoutesNames.POLAZNIK_PREGLED}
                    className="btn btn-danger siroko">
                    Odustani
                    </Link>
                    </Col>
                    <Col xs={6} sm={6} md={9} lg={6} xl={6} xxl={6}>
                    <Button variant="primary" type="submit" className="siroko">
                        Promjeni polaznika
                    </Button>
                    </Col>
                </Row>
            </Form>
        </>
    )
}