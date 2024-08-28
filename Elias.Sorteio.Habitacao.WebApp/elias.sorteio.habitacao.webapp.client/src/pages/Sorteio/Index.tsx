
import { useNavigate } from "react-router-dom";
import { useEffect, useState } from 'react';
import { Pessoa } from "../../models/pessoa";
import { PessoaLista } from "../Pessoa/PessoaLista";
export function Sorteio() {
    const [listaPessoas, setPessoas] = useState<Pessoa[]>();
    const navigate = useNavigate();
    function voltarClick() {
        navigate("/");
    }
    async function obterListaSorteio() {
        const response = await fetch('sorteio');
        const data = await response.json();

        setPessoas(data);

    }

    useEffect(() => {
        obterListaSorteio();
    }, []);
    return (
        <>
            <div className="container"  >
                <div style={{ textAlign: 'center' }}  >
                    <p>Sorteio da Habitação</p>
                    <h1>Ganhadores do Sorteio</h1>
                </div>
                <div style={{ textAlign: 'center' }}  >
                    <h1>Parabéns aos Ganhadores</h1>
                </div>
                <div className="row">
                    <h2>Ganhador Lista Idoso</h2>
                    <PessoaLista listaPessoa={listaPessoas ? listaPessoas.filter(p => p.cota == 'IDOSO') : []} />
                </div>
                <div className="row">
                    <h2>Ganhador Lista Deficiente físico</h2>
                    <PessoaLista listaPessoa={listaPessoas ? listaPessoas.filter(p => p.cota == 'DEFICIENTE FÍSICO') : []} />
                </div>
                <div className="row">
                    <h2>Ganhador Lista Geral</h2>
                    <PessoaLista listaPessoa={listaPessoas ? listaPessoas.filter(p => p.cota == 'GERAL') : []} />
                </div>


                <div className="row">
                    <div className="col-sm">
                        <button className="btn btn-primary" onClick={voltarClick} >Voltar</button>
                    </div>
                </div>
            </div>
        </>
    );
}