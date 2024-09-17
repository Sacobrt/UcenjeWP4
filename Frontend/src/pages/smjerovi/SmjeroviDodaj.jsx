import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link } from "react-router-dom";
import { RoutesNames } from "../../constants";

export default function SmjeroviDodaj() {
    return(
        <Container>
            Dodavanje novog smjera
            <Form>
                <Form.Group constrolId="naziv">
                    <Form.Label>Naziv</Form.Label>
                    <Form.Control type="text" name="naziv" required />
                </Form.Group>
                <Form.Group constrolId="trajanje">
                    <Form.Label>Trajanje</Form.Label>
                    <Form.Control type="number" name="trajanje" min={0} max={500} />
                </Form.Group>
                <Form.Group constrolId="cijena">
                    <Form.Label>Cijena</Form.Label>
                    <Form.Control type="number" name="cijena" min={0} max={500} />
                </Form.Group>
                <Form.Group constrolId="izvodiSeOd">
                    <Form.Label>Izvodi se od</Form.Label>
                    <Form.Control type="date" name="izvodiSeOd" />
                </Form.Group>
                <Form.Group constrolId="vaucer">
                    <Form.Check label="Vaučer" name="vaucer" />
                </Form.Group>
                <hr />
                <Row>
                    <Col xs={6} sm={6} md={3} lg={6} xl={6} xxl={6}>
                        <Link to={RoutesNames.SMJER_PREGLED}
                        className="btn btn-danger siroko">
                            Odustani
                        </Link>
                    </Col>
                    <Col xs={6} sm={6} md={9} lg={6} xl={6} xxl={6}>
                    <Button variant="primary" type="submit" className="siroko">
                        Dodaj novi
                    </Button>
                    </Col>
                </Row>
            </Form>
        </Container>
    )
}
