import { HttpService } from "./HttpService"

async function get(){
    return await HttpService.get('/Smjer')
    .then((odgovor)=>{
        // console.table(odgovor.data);
        return odgovor.data;
    })
    .catch((e)=>{console.error(e)})
}

async function obrisi(sifra) {
    return await HttpService.delete('/Smjer/' + sifra)
    .then((odgovor) => {
        return {greska: false, poruka: odgovor.data.poruka}
    })
    .catch((e) => {
        return {greska: true, poruka: 'Smjer se ne može obrisati!'}
    })
}

export default{
    get,
    obrisi
}
