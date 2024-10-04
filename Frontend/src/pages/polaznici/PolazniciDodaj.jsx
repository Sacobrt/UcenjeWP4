import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import PolaznikService from "../../services/PolaznikService";

import useLoading from "../../hooks/useLoading";



export default function PolazniciDodaj(){

    const navigate = useNavigate();

    const { showLoading, hideLoading } = useLoading();

    async function dodaj(e){
        showLoading();
        const odgovor = await PolaznikService.dodaj(e);
        hideLoading();
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        navigate(RoutesNames.POLAZNIK_PREGLED);
    }

    function obradiSubmit(e){ 
        e.preventDefault();

        const podaci = new FormData(e.target);

        dodaj({
            ime: podaci.get('ime'),
            prezime: podaci.get('prezime'),
            email: podaci.get('email'),
            oib: podaci.get('oib')
        });

    }

    return(
        <>
            Dodavanje novog Polaznika
            
            <Form onSubmit={obradiSubmit}>
                <Form.Group controlId="ime">
                    <Form.Label>Ime</Form.Label>
                    <Form.Control type="text" name="ime" required />
                </Form.Group>

                <Form.Group controlId="prezime">
                    <Form.Label>Prezime</Form.Label>
                    <Form.Control type="text" name="prezime" required />
                </Form.Group>

                <Form.Group controlId="email">
                    <Form.Label>Email</Form.Label>
                    <Form.Control type="text" name="email" required />
                </Form.Group>

                <Form.Group controlId="oib">
                    <Form.Label>oib</Form.Label>
                    <Form.Control type="text" name="oib"  />
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
                        Dodaj novog polaznika
                    </Button>
                    </Col>
                </Row>
            </Form>
        </>
    )
}