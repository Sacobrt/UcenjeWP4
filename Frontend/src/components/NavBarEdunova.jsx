import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { RoutesNames } from '../constants';
import { useNavigate } from 'react-router-dom';


export default function NavBarEdunova(){

    const navigate = useNavigate();

    return(
    <Navbar expand="lg" className="bg-body-tertiary">
        <Navbar.Brand href="/">Edunova APP WP4</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link onClick={()=>navigate(RoutesNames.HOME)}>Početna</Nav.Link>
            <Nav.Link href="http://tjakopec-001-site3.ftempurl.com/swagger/index.html" target='_blank'>Swagger</Nav.Link>
            <NavDropdown title="Programi" id="basic-nav-dropdown">
              <NavDropdown.Item onClick={()=>navigate(RoutesNames.SMJER_PREGLED)}>Smjerovi</NavDropdown.Item>
              <NavDropdown.Item  onClick={()=>navigate(RoutesNames.POLAZNIK_PREGLED)}>
                Polaznici
              </NavDropdown.Item>
              <NavDropdown.Item   onClick={()=>navigate(RoutesNames.GRUPA_PREGLED)}>Grupe</NavDropdown.Item>
            </NavDropdown>
          </Nav>
        </Navbar.Collapse>
    </Navbar>
    );
}