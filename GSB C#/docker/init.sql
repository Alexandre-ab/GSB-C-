-- phpMyAdmin SQL Dump
-- version 5.2.2
-- https://www.phpmyadmin.net/
--
-- Hôte : db:3306
-- Généré le : mer. 10 déc. 2025 à 15:07
-- Version du serveur : 8.1.0
-- Version de PHP : 8.2.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `bts-gsb`
--

-- --------------------------------------------------------

--
-- Structure de la table `Appartient`
--

CREATE TABLE `Appartient` (
  `id_prescription` int NOT NULL,
  `id_medicine` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `Appartient`
--

INSERT INTO `Appartient` (`id_prescription`, `id_medicine`) VALUES
(1, 1),
(1, 2),
(2, 3),
(3, 5);

-- --------------------------------------------------------

--
-- Structure de la table `Medicine`
--

CREATE TABLE `Medicine` (
  `id_medicine` int NOT NULL,
  `id_users` int NOT NULL,
  `name` varchar(150) NOT NULL,
  `molecule` varchar(150) DEFAULT NULL,
  `dosage` varchar(100) DEFAULT NULL,
  `description` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `Medicine`
--

INSERT INTO `Medicine` (`id_medicine`, `id_users`, `name`, `molecule`, `dosage`, `description`) VALUES
(1, 1, 'Paracetamol', 'Paracetamolum', '500 mg', 'Antidouleur et antipyrétique'),
(2, 1, 'Doliprane', 'Paracetamolum', '20 mg', 'Soulage la fièvre et la douleur'),
(3, 2, 'Ibuprofen', 'Ibuprofenum', '10 mg', 'Anti-inflammatoire non stéroïdien'),
(4, 5, 'Amoxicilline', 'Amoxicillin', '50 mg', 'Antibiotique à large spectre'),
(5, 1, 'Xanax', 'Alprazolam', '5 mg', 'Anxiolytique (benzodiazépine)');

-- --------------------------------------------------------

--
-- Structure de la table `Patients`
--

CREATE TABLE `Patients` (
  `id_patients` int NOT NULL,
  `id_users` int NOT NULL,
  `name` varchar(100) NOT NULL,
  `firstname` varchar(100) NOT NULL,
  `age` int DEFAULT NULL,
  `gender` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `Patients`
--

INSERT INTO `Patients` (`id_patients`, `id_users`, `name`, `firstname`, `age`, `gender`) VALUES
(1, 3, 'Lefevre', 'Claire', 25, 0),
(2, 4, 'Bernard', 'David', 45, 1),
(3, 3, 'test', 'test', 25, 1),
(5, 3, 'test1', 'test1', 89, 0),
(6, 3, 'test2', 'test2 ', 85, 1),
(7, 2, 'test9', 'test9', 45, 0);

-- --------------------------------------------------------

--
-- Structure de la table `Prescription`
--

CREATE TABLE `Prescription` (
  `id_prescription` int NOT NULL,
  `id_patients` int NOT NULL,
  `id_users` int NOT NULL,
  `quantity` int DEFAULT NULL,
  `validity` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `Prescription`
--

INSERT INTO `Prescription` (`id_prescription`, `id_patients`, `id_users`, `quantity`, `validity`) VALUES
(1, 1, 1, 2, '2025-12-31'),
(2, 2, 2, 1, '2025-11-30'),
(3, 1, 5, 3, '2026-01-15');

-- --------------------------------------------------------

--
-- Structure de la table `Users`
--

CREATE TABLE `Users` (
  `id_users` int NOT NULL,
  `firstname` varchar(100) NOT NULL,
  `name` varchar(100) NOT NULL,
  `role` tinyint(1) NOT NULL,
  `email` varchar(150) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `Users`
--

INSERT INTO `Users` (`id_users`, `firstname`, `name`, `role`, `email`, `password`) VALUES
(1, 'Alice', 'Martin', 0, 'alice.martin@example.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4'),
(2, 'Bob', 'Durand', 0, 'bob.durand@example.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4'),
(3, 'Claire', 'Lefevre', 1, 'claire.lefevre@example.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4'),
(4, 'David', 'Bernard', 1, 'david.bernard@example.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4'),
(5, 'Emma', 'Petit', 0, 'emma.petit@example.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4'),
(14, 'Test2', 'Test1 ', 0, 'test@example.com', '756bc47cb5215dc3329ca7e1f7be33a2dad68990bb94b76d90aa07f4e44a233a');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `Appartient`
--
ALTER TABLE `Appartient`
  ADD PRIMARY KEY (`id_prescription`,`id_medicine`),
  ADD KEY `id_medicine` (`id_medicine`);

--
-- Index pour la table `Medicine`
--
ALTER TABLE `Medicine`
  ADD PRIMARY KEY (`id_medicine`),
  ADD KEY `id_users` (`id_users`);

--
-- Index pour la table `Patients`
--
ALTER TABLE `Patients`
  ADD PRIMARY KEY (`id_patients`),
  ADD KEY `id_users` (`id_users`);

--
-- Index pour la table `Prescription`
--
ALTER TABLE `Prescription`
  ADD PRIMARY KEY (`id_prescription`),
  ADD KEY `id_patients` (`id_patients`),
  ADD KEY `id_users` (`id_users`);

--
-- Index pour la table `Users`
--
ALTER TABLE `Users`
  ADD PRIMARY KEY (`id_users`),
  ADD UNIQUE KEY `email` (`email`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `Medicine`
--
ALTER TABLE `Medicine`
  MODIFY `id_medicine` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT pour la table `Patients`
--
ALTER TABLE `Patients`
  MODIFY `id_patients` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT pour la table `Prescription`
--
ALTER TABLE `Prescription`
  MODIFY `id_prescription` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT pour la table `Users`
--
ALTER TABLE `Users`
  MODIFY `id_users` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `Appartient`
--
ALTER TABLE `Appartient`
  ADD CONSTRAINT `Appartient_ibfk_1` FOREIGN KEY (`id_prescription`) REFERENCES `Prescription` (`id_prescription`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `Appartient_ibfk_2` FOREIGN KEY (`id_medicine`) REFERENCES `Medicine` (`id_medicine`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `Medicine`
--
ALTER TABLE `Medicine`
  ADD CONSTRAINT `Medicine_ibfk_1` FOREIGN KEY (`id_users`) REFERENCES `Users` (`id_users`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `Patients`
--
ALTER TABLE `Patients`
  ADD CONSTRAINT `Patients_ibfk_1` FOREIGN KEY (`id_users`) REFERENCES `Users` (`id_users`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `Prescription`
--
ALTER TABLE `Prescription`
  ADD CONSTRAINT `Prescription_ibfk_1` FOREIGN KEY (`id_patients`) REFERENCES `Patients` (`id_patients`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `Prescription_ibfk_2` FOREIGN KEY (`id_users`) REFERENCES `Users` (`id_users`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

