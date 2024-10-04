import { Button, Table } from "react-bootstrap";
import PolaznikService from "../../services/PolaznikService";
import { useEffect, useState } from "react";
import { RoutesNames } from "../../constants";
import { Link, useNavigate } from "react-router-dom";

import useLoading from "../../hooks/useLoading";



export default function PolazniciPregled(){

    const[polaznici,setPolaznici] = useState();

    const navigate = useNavigate();

    const { showLoading, hideLoading } = useLoading();

    async function dohvatiPolaznike() {

        // zaustavi kod u Chrome consoli i tamo se može raditi debug
        //debugger;
        showLoading();
        await PolaznikService.get()
        .then((odgovor)=>{
            //console.log(odgovor);
            setPolaznici(odgovor);
        })
        .catch((e)=>{console.log(e)});
        hideLoading();
    }

    // npm run lint
    // javlja upozorenje
    // 28:7  warning  React Hook useEffect has a missing dependency: 'dohvatie'. Either include it or remove the dependency array  react-hooks/exhaustive-deps

    useEffect(()=>{
        dohvatiPolaznike();
    },[]);

   

    async function obrisiAsync(sifra) {
        showLoading();
        const odgovor = await PolaznikService.obrisi(sifra);
        hideLoading();
        //console.log(odgovor);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        dohvatiPolaznike();
    }

    function obrisi(sifra){
        obrisiAsync(sifra);
    }


    return(
        <>
            <Link to={RoutesNames.POLAZNIK_NOVI}>Dodaj novog polaznika</Link>
            <Table striped bordered hover responsive>
                <thead>
                    <tr>
                        <th>Ime</th>
                        <th>Prezime</th>
                        <th>Email</th>
                        <th>OIB</th>
                        <th>Akcija</th>
                    </tr>
                </thead>
                <tbody>
                    {polaznici && polaznici.map((e,index)=>(
                        <tr key={index}>
                            <td>{e.ime}</td>
                            <td>{e.prezime}</td>
                            <td>{e.email}</td>
                            <td>{e.oib}</td>
                           
                            <td>
                            <Button
                                variant="primary"
                                onClick={()=>navigate(`/polaznici/${e.sifra}`)}>
                                    Promjeni
                                </Button>
                                &nbsp;&nbsp;&nbsp;
                                <Button
                                variant="danger"
                                onClick={()=>obrisi(e.sifra)}>
                                    Obriši
                                </Button>

                               
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </>
    )

}