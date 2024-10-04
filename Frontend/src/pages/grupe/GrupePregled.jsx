import { useEffect, useState } from "react";
import { Button, Container, Table } from "react-bootstrap";
import { IoIosAdd } from "react-icons/io";
import { FaEdit, FaTrash } from "react-icons/fa";
import { Link } from "react-router-dom";
import { useNavigate } from "react-router-dom";

import Service from "../../services/GrupaService"; // primjetite promjenu naziva
import { RoutesNames } from "../../constants";

import useLoading from "../../hooks/useLoading";

export default function GrupePregled(){
    const [grupe,setGrupe] = useState();
    let navigate = useNavigate(); 
    const { showLoading, hideLoading } = useLoading();

    async function dohvatiGrupe(){
        showLoading();
        await Service.get()
        .then((odgovor)=>{
            //console.log(odgovor);
            setGrupe(odgovor);
        })
        .catch((e)=>{console.log(e)});
        hideLoading();
    }

    async function obrisiGrupu(sifra) {
        showLoading();
        const odgovor = await Service.obrisi(sifra);
        hideLoading();
        //console.log(odgovor);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        dohvatiGrupe();
    }

    useEffect(()=>{
        dohvatiGrupe();
        // eslint-disable-next-line react-hooks/exhaustive-deps
    },[]);


    return (

        <Container>
            <Link to={RoutesNames.GRUPA_NOVI} className="btn btn-success siroko">
                <IoIosAdd
                size={25}
                /> Dodaj
            </Link>
            <Table striped bordered hover responsive>
                <thead>
                    <tr>
                        <th>Naziv</th>
                        <th>Smjer</th>
                        <th>Predavač</th>
                        <th>Maksimalno polaznika</th>
                        <th>Akcija</th>
                    </tr>
                </thead>
                <tbody>
                    {grupe && grupe.map((entitet,index)=>(
                        <tr key={index}>
                            <td>{entitet.naziv}</td>
                            <td>{entitet.smjerNaziv}</td>
                            <td>{entitet.predavac}</td>
                            <td>{entitet.maksimalnoPolaznika}</td>
                            <td className="sredina">
                                    <Button
                                        variant='primary'
                                        onClick={()=>{navigate(`/grupe/${entitet.sifra}`)}}
                                    >
                                        <FaEdit 
                                    size={25}
                                    />
                                    </Button>
                               
                                
                                    &nbsp;&nbsp;&nbsp;
                                    <Button
                                        variant='danger'
                                        onClick={() => obrisiGrupu(entitet.sifra)}
                                    >
                                        <FaTrash
                                        size={25}/>
                                    </Button>

                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>

    );

}