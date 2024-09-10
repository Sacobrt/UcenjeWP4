import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { useNavigate } from 'react-router-dom';
import { RoutesNames } from '../constants';

export default function NavBarEdunova()
{
    const navigate = useNavigate();

    return (
        <>
            <Navbar expand="lg" className="bg-body-tertiary">
                <Container>
                <Navbar.Brand href="#home">Edunova APP</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="me-auto">
                    <Nav.Link onClick={() => navigate(RoutesNames.HOME)}>Početna</Nav.Link>
                    <Nav.Link href="https://tjakopec-001-site1.ftempurl.com/swagger/index.html" target="_blank">Swagger</Nav.Link>
                    <NavDropdown title="Programi" id="basic-nav-dropdown">
                        <NavDropdown.Item onClick={() => navigate(RoutesNames.SMJER_PREGLED)}>Smjerovi</NavDropdown.Item>
                        <NavDropdown.Item href="#action/3.2">Polazinici</NavDropdown.Item>
                        <NavDropdown.Item href="#action/3.3">Članovi</NavDropdown.Item>
                        <NavDropdown.Item href="#action/3.4">Grupe</NavDropdown.Item>
                    </NavDropdown>
                    </Nav>
                </Navbar.Collapse>
                </Container>
            </Navbar>
        </>
    );
}