/*
 Navicat Premium Data Transfer

 Source Server         : 192.168.33.128
 Source Server Type    : MySQL
 Source Server Version : 50735
 Source Host           : 192.168.33.128:3306
 Source Schema         : demo

 Target Server Type    : MySQL
 Target Server Version : 50735
 File Encoding         : 65001

 Date: 15/11/2021 14:11:02
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for enterprise
-- ----------------------------
DROP TABLE IF EXISTS `enterprise`;
CREATE TABLE `enterprise`  (
  `Id` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Industry` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `LogoUrl` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Province` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `City` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `AgentId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `AddTime` datetime(0) NOT NULL,
  `UpdateTime` datetime(0) NOT NULL,
  `Dr` int(11) DEFAULT NULL,
  `Ts` datetime(0) NOT NULL,
  `AuthStatus` int(11) NOT NULL COMMENT '0全部授权,1未授权,2部分授权',
  `EnableStatus` int(11) NOT NULL COMMENT '0启用，1停用，2应用删除',
  `AuthUserId` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '授权用户id,逗号分隔',
  `AuthDeptId` text CHARACTER SET utf8 COLLATE utf8_general_ci COMMENT '授权部门id,逗号分隔',
  `MaxVehicleCount` int(11) DEFAULT NULL,
  `ServiceStopTime` datetime(0) DEFAULT NULL,
  `ChargeType` smallint(6) DEFAULT NULL COMMENT '1.试用规格2.免费规格3.付费开通',
  `SpecCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `SpecName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `GoodsCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `GoodsName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `MaxDeviceCount` int(11) DEFAULT NULL,
  `MainCorpId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '订单主企业id',
  `PlatForm` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '平台',
  `PermanentCode` varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL COMMENT '永久授权码',
  `AuthMode` smallint(6) DEFAULT NULL COMMENT '授权模式，0为管理员授权；1为成员授权',
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
